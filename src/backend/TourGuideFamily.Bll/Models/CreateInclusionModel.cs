namespace TourGuideFamily.Bll.Models;

public record CreateInclusionModel
{
    public required string Description { get; init; }
    public required bool Include { get; init; }
}