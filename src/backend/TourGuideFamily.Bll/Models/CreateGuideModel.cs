using Microsoft.AspNetCore.Http;

namespace TourGuideFamily.Bll.Models;

public record CreateGuideModel
{
    public required IFormFile Image { get; init; }
    public required string Firstname { get; init; }
    public required string Surname { get; init; }
    public required string Description { get; init; }
}