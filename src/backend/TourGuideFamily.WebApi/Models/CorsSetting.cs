namespace TourGuideFamily.WebApi.Models;

internal record CorsSetting
{
    internal string[] Urls { get; init; }
}