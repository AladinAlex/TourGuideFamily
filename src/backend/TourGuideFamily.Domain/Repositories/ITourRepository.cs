using System.Data;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface ITourRepository
{
    Task<long> AddAsync(Tour entity, CancellationToken token, IDbTransaction transaction);
    Task<TourInfoModel[]> GetToursInfo(CancellationToken token);
    Task<TourModel> GetById(long tourId, CancellationToken token);
    Task<int> GetCountBySlug(string slug, CancellationToken token);
    Task<long> GetTourIdBySlug(string slug, CancellationToken token);
    Task<TourLinkModel[]> GetTourLink(int? limit, CancellationToken token);
}