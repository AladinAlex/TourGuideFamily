namespace Storage.Bll.Services.Interfaces;

public interface IUploadService
{
    Task<string> UploadFileAsync(string fileName, byte[] fileData, string scheme, string host);
}