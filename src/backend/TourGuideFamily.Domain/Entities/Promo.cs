using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourGuideFamily.Domain.Entities;

public record Promo
{
    public long Id { get; init; }
    public long? TourId { get; init; }
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}