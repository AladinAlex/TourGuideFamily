namespace TourGuideFamily.Domain.Entities;

public record TourDay
{
    public long Id { get; init; }
    public required long TourId { get; init; }
    public required short Number { get; init; }
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}