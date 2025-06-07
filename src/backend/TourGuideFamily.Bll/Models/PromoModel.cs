namespace TourGuideFamily.Bll.Models;

public record PromoModel
{
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}