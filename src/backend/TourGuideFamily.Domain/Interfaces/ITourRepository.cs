using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface ITourRepository
{
    Task<long> AddAsync(Tour entity, CancellationToken token);
    Task<TourInfoModel[]> GetToursInfo(CancellationToken token);
    Task<TourModel> GetById(long tourId, CancellationToken token);
}