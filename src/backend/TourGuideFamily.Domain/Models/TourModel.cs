namespace TourGuideFamily.Domain.Models;

public record TourModel
{
    public required string Name { get; init; }
    public required string Image { get; init; }
    public required short MinParticipants { get; init; }
    public required short MaxParticipants { get; init; }
    public required decimal Price { get; init; }
    public short? DurationHourMin { get; init; }
    public short? DurationHourMax { get; init; }
    public required string Description { get; init; }
    public required string DescriptionImage { get; init; }
}