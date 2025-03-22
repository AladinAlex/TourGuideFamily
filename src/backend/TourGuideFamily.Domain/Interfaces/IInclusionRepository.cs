using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface IInclusionRepository
{
    Task<InclusionModel[]> GetByTourId(long tourId, CancellationToken token);
}