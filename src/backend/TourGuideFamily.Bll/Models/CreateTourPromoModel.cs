using Microsoft.AspNetCore.Http;

namespace TourGuideFamily.Bll.Models;

public record CreateTourPromoModel
{
    public required IFormFile Image { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}