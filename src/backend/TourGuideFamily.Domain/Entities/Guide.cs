using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourGuideFamily.Domain.Entities;

public record Guide
{
    public long Id { get; init; }
    public required string Image { get; init; }
    public required string Firstname { get; init; }
    public required string Surname { get; init; }
    public required string Description { get; init; }
}