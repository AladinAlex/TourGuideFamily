using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Bll.Services.Interfaces;

public interface IFeedbackService
{
    Task Create(CreateFeedback model, CancellationToken token);
}
