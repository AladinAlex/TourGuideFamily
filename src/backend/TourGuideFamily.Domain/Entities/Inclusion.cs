namespace TourGuideFamily.Domain.Entities;

public record Inclusion
{
    public long Id { get; init; }
    public required long TourId { get; init; }
    public required string Description { get; init; }
    public required bool Include { get; init; }
}