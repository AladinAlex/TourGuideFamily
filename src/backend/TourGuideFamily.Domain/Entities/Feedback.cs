namespace TourGuideFamily.Domain.Entities;

public record Feedback
{
    public long Id { get; init; }
    public required string Firstname { get; init; }
    public required string PhoneNumber { get; init; }
    public required short ContactMethod { get; init; }
    public long? TourId { get; init; }
    public DateTimeOffset CreatedOn { get; init; }
}