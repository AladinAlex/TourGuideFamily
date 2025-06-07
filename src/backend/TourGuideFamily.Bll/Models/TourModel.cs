using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Bll.Models;

public class TourModel
{
    public required string Image { get; init; }
    public required string Name { get; init; }
    public required short MinParticipants { get; init; }
    public required short MaxParticipants { get; init; }
    public required decimal Price { get; init; }
    public short? DurationHourMin { get; init; }
    public short? DurationHourMax { get; init; }
    public required TourDayModel[] Days { get; init; }
    public required PromoTourModel[] Promos  { get; init; }
    public required string[] Included  { get; init; }
    public required string[] Excluded  { get; init; }
    public required string DescriptionImage { get; init; }
    public required string Description { get; init; }
}