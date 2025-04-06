namespace TourGuideFamily.WebApi.Models;

internal record CorsSetting
{
    public string[] Urls { get; init; }
}