namespace TourGuideFamily.Domain.Models;

public record TourLinkModel
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
}
