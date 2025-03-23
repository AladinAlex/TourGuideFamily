using Storage.Bll.Consts;
using Storage.Bll.Services.Interfaces;

namespace Storage.Bll.Services;
public class UploadService : IUploadService
{
    private readonly string _storagePath;

    public UploadService()
    {
        _storagePath = Path.Combine(AppContext.BaseDirectory, StorageResourse.ResourseFolderName);
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public async Task<string> UploadFileAsync(string fileName, byte[] fileData, string scheme, string host, int? port)
    {
        var uniqueFileName = await SaveFileToStorage(fileName, fileData);
        return GenerateFileUrl(uniqueFileName, scheme, host, port);
    }

    private async Task<string> SaveFileToStorage(string fileName, byte[] fileData)
    {
        var fileExtension = Path.GetExtension(fileName);
        var uniqueFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{Guid.NewGuid()}{fileExtension}";
        var filePath = Path.Combine(_storagePath, uniqueFileName);

        using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        await stream.WriteAsync(fileData, 0, fileData.Length);

        return uniqueFileName;
    }

    public string GenerateFileUrl(string fileName, string scheme, string host, int? port)
    {
        return $"{scheme}://{host}:{port}/{StorageResourse.ResourseFolderName}/{fileName}";
    }
}