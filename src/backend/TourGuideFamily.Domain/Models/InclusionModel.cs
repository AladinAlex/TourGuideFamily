namespace TourGuideFamily.Domain.Models;

public record InclusionModel
{
    public required string Description { get; init; }
    public required bool Include { get; init; }
}