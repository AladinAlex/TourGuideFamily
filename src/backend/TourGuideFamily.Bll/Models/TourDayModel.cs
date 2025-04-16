namespace TourGuideFamily.Bll.Models;

public record TourDayModel
{
    public required short Number { get; init; }
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
