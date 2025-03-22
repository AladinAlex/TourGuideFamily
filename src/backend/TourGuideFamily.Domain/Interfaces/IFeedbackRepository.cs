using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface IFeedbackRepository
{
    Task<long> AddAsync(CreateFeedbackModel entity, CancellationToken token);
}