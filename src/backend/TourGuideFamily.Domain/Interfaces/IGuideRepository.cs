using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface IGuideRepository
{
    Task<long> AddAsync(CreateGuide entity, CancellationToken token);
    Task<GuideModel[]> GetAllAsync(CancellationToken token);
}