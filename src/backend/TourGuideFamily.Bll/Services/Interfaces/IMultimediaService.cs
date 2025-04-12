using Microsoft.AspNetCore.Http;

namespace TourGuideFamily.Bll.Services.Interfaces;

public interface IMultimediaService
{
    Task<string> UploadImageAsync(IFormFile file, CancellationToken token);
}