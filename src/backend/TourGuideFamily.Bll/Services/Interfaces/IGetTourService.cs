using TourGuideFamily.Bll.Models;

namespace TourGuideFamily.Bll.Services.Interfaces;

public interface IGetTourService
{
    Task<MainModel> Main(CancellationToken token);
    Task<TourModel> Tour(long tourId, CancellationToken token);
}