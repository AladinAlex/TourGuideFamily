using TourGuideFamily.Domain.Enums;

namespace TourGuideFamily.Bll.Models;

public record CreateFeedbackModel
{
    public required string Firstname { get; init; }
    public required string PhoneNumber { get; init; }
    public required СontactMethod ContactMethod { get; init; }
    public long? TourId { get; init; }
}