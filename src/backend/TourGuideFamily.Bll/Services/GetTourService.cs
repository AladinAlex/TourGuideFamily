using Microsoft.Extensions.Configuration;
using TourGuideFamily.Bll.Models;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.Domain.Interfaces;

namespace TourGuideFamily.Bll.Services;

public class GetTourService : IGetTourService
{
    readonly IGuideRepository _guideRepository;
    readonly ITourRepository _tourRepository;
    readonly IPromoRepository _promoRepository;
    readonly ITourDayRepository _tourDayRepository;
    readonly IInclusionRepository _inclusionRepository;
    readonly IConfiguration _config;
    private string _storageUrl;

    public GetTourService(IGuideRepository guideRepository,
        ITourRepository tourRepository,
        IPromoRepository promoRepository,
        ITourDayRepository tourDayRepository,
        IInclusionRepository inclusionRepository,
        IConfiguration config)
    {
        _guideRepository = guideRepository;
        _tourRepository = tourRepository;
        _promoRepository = promoRepository;
        _tourDayRepository = tourDayRepository;
        _inclusionRepository = inclusionRepository;
        _config = config;
        _storageUrl = _config["Storage:Url"]!;
    }

    public async Task<MainModel> Main(CancellationToken token)
    {
        var guideTask = _guideRepository.GetAllAsync(token);
        var toursInfoTask = _tourRepository.GetToursInfo(token);
        var promoTask = _promoRepository.GetMainPromo(token);

        await Task.WhenAll(guideTask, toursInfoTask, promoTask);

        var guide = guideTask.Result.Select(x => new GuideModel
        {
            Description = x.Description,
            Firstname = x.Firstname,
            Surname = x.Surname,
            Image = $"{_storageUrl}/{x.Image}"
        }).ToArray();
        var toursInfo = toursInfoTask.Result.Select(x => new TourInfoModel
        {
            Image = $"{_storageUrl}/{x.Image}",
            MaxParticipants = x.MaxParticipants,
            MinParticipants = x.MinParticipants,
            Name = x.Name,
            Price = x.Price,
            Slug = x.Slug,
            DayCount = x.DayCount,
            DurationHour = x.DurationHour,
        }).ToArray();
        var promo = promoTask.Result.Select(x => new PromoModel
        {
            Description = x.Description,
            Image = $"{_storageUrl}/{x.Image}",
            Name = x.Name,
        }).ToArray();

        return new MainModel
        {
            Guides = guide,
            Promos = promo,
            Tours = toursInfo,
        };
    }

    public async Task<TourModel> Tour(string slug, CancellationToken token)
    {
        var tourId = await _tourRepository.GetTourIdBySlug(slug, token);
        var tourTask = _tourRepository.GetById(tourId, token);
        var daysTask = _tourDayRepository.GetByTourId(tourId, token);
        var promosTask = _promoRepository.GetByTourId(tourId, token);
        var inclusionsTask = _inclusionRepository.GetByTourId(tourId, token);

        await Task.WhenAll(tourTask, daysTask, promosTask, inclusionsTask);

        var tour = tourTask.Result;
        var days = daysTask.Result.Select(x => new TourDayModel
        {
            Description = x.Description,
            Name = x.Name,
            Number = x.Number,
            Image = $"{_storageUrl}/{x.Image}",
        }).ToArray();
        var promos = promosTask.Result.Select(x => new PromoTourModel
        {
            Description = x.Description,
            Name = x.Name,
            Image = $"{_storageUrl}/{x.Image}",
        }).ToArray();
        var inclusions = inclusionsTask.Result;
        var included = inclusions.Where(x => x.Include).Select(x => x.Description).ToArray();
        var excluded = inclusions.Where(x => !x.Include).Select(x => x.Description).ToArray();

        return new TourModel
        {
            Name = tour.Name,
            Image = $"{_storageUrl}/{tour.Image}",
            MinParticipants = tour.MinParticipants,
            MaxParticipants = tour.MaxParticipants,
            Price = tour.Price,
            DurationHour = tour.DurationHour,
            Days = days,
            Promos = promos,
            Included = included,
            Excluded = excluded,
        };
    }
}