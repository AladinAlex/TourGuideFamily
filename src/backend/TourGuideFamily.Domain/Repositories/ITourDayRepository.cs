using System.Data;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface ITourDayRepository
{
    Task<long[]> AddRangeAsync(TourDay[] entities, CancellationToken token, IDbTransaction transaction);
    Task<TourDayModel[]> GetByTourId(long tourId, CancellationToken token);
}