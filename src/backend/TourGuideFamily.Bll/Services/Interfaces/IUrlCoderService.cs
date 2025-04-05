namespace TourGuideFamily.Bll.Services.Interfaces;

public interface IUrlCoderService
{
    Task<string> EncodeToSlugAsync(string input, CancellationToken token);
}