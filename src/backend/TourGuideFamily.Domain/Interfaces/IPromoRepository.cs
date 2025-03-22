using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface IPromoRepository
{
    Task<long[]> AddRangeAsync(Promo[] entities, CancellationToken token);
    Task<PromoModel[]> GetMainPromo(CancellationToken token);
    Task<PromoTourModel[]> GetByTourId(long tourId, CancellationToken token);
}