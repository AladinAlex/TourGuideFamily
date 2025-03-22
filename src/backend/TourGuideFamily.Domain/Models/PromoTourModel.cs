namespace TourGuideFamily.Domain.Models;

public record PromoTourModel
{
    public required long Id { get; init; }
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}