using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourGuideFamily.Domain.Entities;

public record Tour
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required short MinParticipants { get; init; }
    public required short MaxParticipants { get; init; }
    public required decimal Price { get; init; }
    public short? DurationHour { get; init; }
}
