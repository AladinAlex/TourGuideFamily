using Microsoft.AspNetCore.Http;

namespace TourGuideFamily.Bll.Models;

public class CreateTourModel
{
    public required IFormFile Image { get; init; }
    public required string Name { get; init; }
    public required short MinParticipants { get; init; }
    public required short MaxParticipants { get; init; }
    public required decimal Price { get; init; }
    public short? DurationHour { get; init; }
    public CreateTourPromoModel[]? Promos { get; init; }
    public CreateTourDayModel[]? Days { get; init; }
    public CreateInclusionModel[]? Inclusions { get; init; }
}