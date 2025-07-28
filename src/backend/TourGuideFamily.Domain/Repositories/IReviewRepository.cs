using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface IReviewRepository
{
    Task<long> AddAsync(Review entity, CancellationToken token);
    Task<ReviewModel[]> GetAsync(int limit, CancellationToken token);

}