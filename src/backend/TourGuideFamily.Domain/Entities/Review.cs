namespace TourGuideFamily.Domain.Entities;

public record Review
{
    public long Id { get; init; }
    public required string Firstname { get; init; }
    public required short Rating { get; init; }
    public string? TourName { get; init; }
    public required string Description { get; init; }
    public required DateOnly CreatedOn { get; init; }
}