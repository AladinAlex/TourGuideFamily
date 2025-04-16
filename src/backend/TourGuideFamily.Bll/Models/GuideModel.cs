namespace TourGuideFamily.Bll.Models;

public record GuideModel
{
    public required string Image { get; init; }
    public required string Firstname { get; init; }
    public required string Surname { get; init; }
    public required string Description { get; init; }
}
