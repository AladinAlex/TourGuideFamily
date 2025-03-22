using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Domain.Interfaces;

public interface ITourDayRepository
{
    Task<long[]> AddRangeAsync(TourDay[] entities, CancellationToken token);
    Task<TourDayModel[]> GetByTourId(long tourId, CancellationToken token);
}