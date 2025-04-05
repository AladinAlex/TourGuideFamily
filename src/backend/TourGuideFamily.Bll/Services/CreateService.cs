using System.Transactions;
using TourGuideFamily.Bll.Models;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Bll.Services;

public class CreateService : ICreateService
{
    readonly IGuideRepository _guideRepository;
    readonly IPromoRepository _promoRepository;
    readonly IMultimediaService _multimediaService;
    readonly IFeedbackRepository _feedbackRepository;
    readonly ITourRepository _tourRepository;
    readonly ITourDayRepository _tourDayRepository;
    readonly IInclusionRepository _inclusionRepository;
    readonly IDateTimeService _dateTimeService;
    readonly IUnitOfWork _unitOfWork;
    readonly IUrlCoderService _urlCoderService;
    public CreateService(IGuideRepository guideRepository,
        IMultimediaService multimediaService,
        IPromoRepository promoRepository,
        ITourRepository tourRepository,
        ITourDayRepository tourDayRepository,
        IInclusionRepository inclusionRepository,
        IDateTimeService dateTimeService,
        IFeedbackRepository feedbackRepository,
        IUnitOfWork unitOfWork,
        IUrlCoderService urlCoderService)
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

        var createModel = new CreateFeedback
        {
            Firstname = model.Firstname,
            PhoneNumber = model.PhoneNumber,
            ContactMethod = (short)model.ContactMethod,
            TourId = model.TourId,
            CreatedOn = _dateTimeService.GetDateTimeOffset()
        };
        var id = await _feedbackRepository.AddAsync(createModel, token);
        return id;
    }
    public async Task<long> Tour(CreateTourModel model, CancellationToken token)
    {
        try
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();

            var tourImageUrl = await _multimediaService.UploadImageAsync(model.Image, token);

            var slug = await _urlCoderService.EncodeToSlugAsync(model.Name, token);
            var createTourModel = new Tour
            {
                Image = tourImageUrl,
                Name = model.Name,
                Description = model.Description,
                MinParticipants = model.MinParticipants,
                MaxParticipants = model.MaxParticipants,
                Price = model.Price,
                DurationHour = model.DurationHour,
                Slug = slug
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

}