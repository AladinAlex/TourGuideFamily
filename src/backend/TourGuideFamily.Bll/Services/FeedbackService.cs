using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Bll.Services;

public class FeedbackService : IFeedbackService
{
    readonly IFeedbackRepository _feedbackRepository;
    public FeedbackService(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task Create(CreateFeedback model, CancellationToken token)
    {
        await _feedbackRepository.AddAsync(model, token);
        //TODO: добавить транзакцию и отправлять уведомление в телеграмм
    }
}