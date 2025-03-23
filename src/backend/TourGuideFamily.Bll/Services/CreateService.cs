using System.Transactions;
using TourGuideFamily.Bll.Models;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Bll.Services;

public class CreateService : ICreateService
{
    readonly IGuideRepository _guideRepository;
    readonly IMultimediaService _multimediaService;
    public CreateService(IGuideRepository guideRepository, IMultimediaService multimediaService)
    {
        _guideRepository = guideRepository;
        _multimediaService = multimediaService;
    }

    public async Task<long> Guide(CreateGuideModel model, CancellationToken token)
    {
        using var transaction = CreateTransactionScope();
        try
        {
            var imageUrl = await _multimediaService.UploadImageAsync(model.Image, token);
            var createModel = new CreateGuide
            {
                Description = model.Description,
                Firstname = model.Firstname,
                Surname = model.Surname,
                Image = imageUrl
            };
            var id = await _guideRepository.AddAsync(createModel, token);
            transaction.Complete();
            return id;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private TransactionScope CreateTransactionScope(
    IsolationLevel level = IsolationLevel.ReadCommitted)
    {
        return new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = level,
                Timeout = TimeSpan.FromSeconds(5)
            },
            TransactionScopeAsyncFlowOption.Enabled);
    }
}