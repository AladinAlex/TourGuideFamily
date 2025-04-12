namespace TourGuideFamily.Domain.Models;

public record CreateFeedback
{
    public required string Firstname { get; init; }
    public required string PhoneNumber { get; init; }
    public required short ContactMethod { get; init; }
    public long? TourId { get; init; }
    public DateTimeOffset CreatedOn { get; init; }
}