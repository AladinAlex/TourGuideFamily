namespace TourGuideFamily.Bll.Models;

public record TourInfoModel
{
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required short MinParticipants { get; init; }
    public required short MaxParticipants { get; init; }
    public required decimal Price { get; init; }
    public short? DurationHourMin { get; init; }
    public short? DurationHourMax { get; init; }
    public short? DayCount { get; init; }
    public required string Slug { get; init; }
}