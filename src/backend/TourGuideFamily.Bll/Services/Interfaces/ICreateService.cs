using TourGuideFamily.Bll.Models;

namespace TourGuideFamily.Bll.Services.Interfaces;

public interface ICreateService
{
    Task<long> Guide(CreateGuideModel model, CancellationToken token);
}