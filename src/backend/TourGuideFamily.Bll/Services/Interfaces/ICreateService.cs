using TourGuideFamily.Bll.Models;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Bll.Services.Interfaces;

public interface ICreateService
{
    Task<long> Guide(CreateGuideModel model, CancellationToken token);
    Task<long> Promo(CreatePromoModel model, CancellationToken token);
    Task<long> Feedback(CreateFeedbackModel model, CancellationToken token);
    Task<long> Tour(CreateTourModel model, CancellationToken token);
    Task<long> Review(CreateReviewModel model, CancellationToken token);
}