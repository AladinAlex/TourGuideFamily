namespace TourGuideFamily.Domain.Models;

public record TourInfoModel
{
    public required long Id { get; init; }
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required short MinParticipants { get; init; }
    public required short MaxParticipants { get; init; }
    public required decimal Price { get; init; }
    public short? DurationHour { get; init; }
    public short? DayCount { get; init; }
}