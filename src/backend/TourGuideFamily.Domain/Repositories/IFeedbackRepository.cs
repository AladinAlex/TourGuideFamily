using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface IFeedbackRepository
{
    Task<long> AddAsync(CreateFeedback entity, CancellationToken token);
}