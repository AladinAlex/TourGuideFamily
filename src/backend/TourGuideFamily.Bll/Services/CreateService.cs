using System.Transactions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TelegramService;
using TelegramService.Models;
using TelegramService.Settings;
using TourGuideFamily.Bll.Models;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.Bll.Utils;
using TourGuideFamily.Dal.Repositories;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Bll.Services;

public class CreateService : ICreateService
{
    private readonly ILogger<CreateService> _logger;
    readonly IGuideRepository _guideRepository;
    readonly IPromoRepository _promoRepository;
    readonly IMultimediaService _multimediaService;
    readonly IFeedbackRepository _feedbackRepository;
    readonly ITourRepository _tourRepository;
    readonly ITourDayRepository _tourDayRepository;
    readonly IInclusionRepository _inclusionRepository;
    readonly IReviewRepository _reviewRepository;
    readonly IDateTimeService _dateTimeService;
    readonly IUnitOfWork _unitOfWork;
    readonly IUrlCoderService _urlCoderService;
    readonly ITelegramApiService _telegramApiService;
    readonly Telegram _telegram;
    public CreateService(IGuideRepository guideRepository,
        IMultimediaService multimediaService,
        IPromoRepository promoRepository,
        ITourRepository tourRepository,
        ITourDayRepository tourDayRepository,
        IInclusionRepository inclusionRepository,
        IDateTimeService dateTimeService,
        IFeedbackRepository feedbackRepository,
        IUnitOfWork unitOfWork,
        IUrlCoderService urlCoderService,
        ITelegramApiService telegramApiService,
        IOptions<Telegram> optionTg,
        ILogger<CreateService> logger,
        IReviewRepository reviewRepository)
    {
        _guideRepository = guideRepository;
        _multimediaService = multimediaService;
        _promoRepository = promoRepository;
        _tourRepository = tourRepository;
        _tourDayRepository = tourDayRepository;
        _inclusionRepository = inclusionRepository;
        _feedbackRepository = feedbackRepository;
        _dateTimeService = dateTimeService;
        _unitOfWork = unitOfWork;
        _urlCoderService = urlCoderService;
        _telegramApiService = telegramApiService;
        _telegram = optionTg.Value;
        _logger = logger;
        _reviewRepository = reviewRepository;
    }

    public async Task<long> Guide(CreateGuideModel model, CancellationToken token)
    {
        try
        {
            var imageUrl = await _multimediaService.UploadImageAsync(model.Image, token);
            var createModel = new CreateGuide
            {
                Description = model.Description,
                Firstname = model.Firstname,
                Surname = model.Surname,
                Image = imageUrl
            };
            var id = await _guideRepository.AddAsync(createModel, token);
            return id;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<long> Promo(CreatePromoModel model, CancellationToken token)
    {
        try
        {
            var imageUrl = await _multimediaService.UploadImageAsync(model.Image, token);
            var createModel = new Promo
            {
                Name = model.Name,
                Description = model.Description,
                Image = imageUrl
            };
            var id = await _promoRepository.AddRangeAsync(new[] { createModel }, token);

            return id[0];
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<long> Feedback(CreateFeedbackModel model, CancellationToken token)
    {
        long? tourId = null;
        if (!string.IsNullOrWhiteSpace(model.Slug))
        {
            tourId = await _tourRepository.GetTourIdBySlug(model.Slug, token);
        }
        var createModel = new CreateFeedback
        {
            Firstname = model.Firstname,
            PhoneNumber = model.PhoneNumber,
            ContactMethod = (short)model.ContactMethod,
            TourId = tourId,
            CreatedOn = _dateTimeService.GetDateTimeOffset()
        };

        string message = "Новая заявка от " + model.Firstname + ". Телефон: " + model.PhoneNumber + ". Способ связи: " + model.ContactMethod.GetDescription();
        using var transaction = CreateTransactionScope();
        var id = await _feedbackRepository.AddAsync(createModel, token);
        var tasks = new List<Task>(_telegram.Chats.Length);
        foreach (long chat in _telegram.Chats)
        {
            tasks.Add(sendMessage(chat, message));
        }
        transaction.Complete();
        return id;
    }
    public async Task<long> Tour(CreateTourModel model, CancellationToken token)
    {
        try
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            var tourImageUrl = await _multimediaService.UploadImageAsync(model.Image, token);
            var tourDescriptionImageUrl = await _multimediaService.UploadImageAsync(model.DescriptionImage, token);

            var slug = await _urlCoderService.EncodeToSlugAsync(model.Name, token);
            var createTourModel = new Tour
            {
                Image = tourImageUrl,
                Name = model.Name,
                MinParticipants = model.MinParticipants,
                MaxParticipants = model.MaxParticipants,
                Price = model.Price,
                DurationHourMin = model.DurationHourMin,
                DurationHourMax = model.DurationHourMax,
                Slug = slug,
                Description = model.Description,
                DescriptionImage = tourDescriptionImageUrl,
                SortOrder = model.SortOrder
            };
            var tourId = await _tourRepository.AddAsync(createTourModel, token, transaction);
            var tasks = new List<Task>();
            if (model.Promos is not null && model.Promos.Length > 0)
            {
                //TODO: cuncurrentList?
                var newPromos = new List<Promo>();
                foreach (var promo in model.Promos)
                {
                    //var task = Task.Factory.StartNew(async () =>
                    //{
                    var promoUrl = await _multimediaService.UploadImageAsync(promo.Image, token);
                    newPromos.Add(new Promo
                    {
                        Description = promo.Description,
                        Image = promoUrl,
                        Name = promo.Name,
                        TourId = tourId
                    });
                    //});
                }
                tasks.Add(_promoRepository.AddRangeAsync(newPromos.ToArray(), token, transaction));
            }
            if (model.Days is not null && model.Days.Length > 0)
            {
                var newDays = new List<TourDay>();
                foreach (var day in model.Days)
                {
                    var dayUrl = await _multimediaService.UploadImageAsync(day.Image, token);
                    newDays.Add(new TourDay
                    {
                        Name = day.Name,
                        Description = day.Description,
                        Number = day.Number,
                        TourId = tourId,
                        Image = dayUrl
                    });
                }
                tasks.Add(_tourDayRepository.AddRangeAsync(newDays.ToArray(), token, transaction));
            }
            if (model.Inclusions is not null && model.Inclusions.Length > 0)
            {
                var newInclusions = new List<Inclusion>();
                foreach (var inclusion in model.Inclusions)
                {
                    newInclusions.Add(new Inclusion
                    {
                        Description = inclusion.Description,
                        Include = inclusion.Include,
                        TourId = tourId
                    });
                }
                tasks.Add(_inclusionRepository.AddRangeAsync(newInclusions.ToArray(), token, transaction));
            }
            await Task.WhenAll(tasks);
            await _unitOfWork.CommitAsync();

            return tourId;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<long> Review(CreateReviewModel model, CancellationToken token)
    {
        var createModel = new Review
        {
            Firstname = model.Firstname,
            Rating = model.Rating,
            TourName = model.TourName,
            Description = model.Description,
            CreatedOn = model.CreatedOn
        };
        var reviewId = await _reviewRepository.AddAsync(createModel, token);
        return reviewId;
    }
    private TransactionScope CreateTransactionScope(
    IsolationLevel level = IsolationLevel.ReadCommitted)
    {
        return new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = level,
                Timeout = TimeSpan.FromSeconds(5)
            },
            TransactionScopeAsyncFlowOption.Enabled);
    }
    private async Task sendMessage(long chat_id, string text)
    {
        bool End = false;
        int counter = 1;
        int mls = 500;
        TelegramServiceResponse response = new();
        while (counter <= 5 && !End)
        {
            response = await _telegramApiService.SendMessage(chat_id, text);
            _logger.LogInformation($"Send to chat_id: {chat_id}; message: {text}; Success: {response}, response: {response.Data}, error: {response.Error}");
            if (response != null && response.Success)
                End = true;
            await Task.Delay(mls);
            counter++;
            mls += 1000;
        }

    }
}