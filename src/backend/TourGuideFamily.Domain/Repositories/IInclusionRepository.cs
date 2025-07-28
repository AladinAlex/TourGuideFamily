using System.Data;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface IInclusionRepository
{
    Task<long[]> AddRangeAsync(Inclusion[] entities, CancellationToken token, IDbTransaction transaction);
    Task<InclusionModel[]> GetByTourId(long tourId, CancellationToken token);
}