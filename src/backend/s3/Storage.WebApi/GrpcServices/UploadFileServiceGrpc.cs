using Grpc.Core;
using Storage.Bll.Services.Interfaces;

namespace Storage.WebApi.GrpcServices;

public class UploadFileServiceGrpc : Storage.GrpcContracts.Api.UploadFileService.UploadFileServiceBase
{
    private readonly string _storagePath;
    private readonly IUploadService _uploadService;
    
    public UploadFileServiceGrpc(IUploadService uploadService)
    {
        _uploadService = uploadService;
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public override async Task<Storage.GrpcContracts.Api.UploadFileResponse> UploadFile(IAsyncStreamReader<Storage.GrpcContracts.Api.UploadFileRequest> requestStream, ServerCallContext context)
    {
        string fileName = default!;
        string contentType;
        byte[] fileData = Array.Empty<byte>();

        try
        {
            // Читаем данные из потока
            while (await requestStream.MoveNext())
            {
                var currentRequest = requestStream.Current;

                if (currentRequest.Metadata != null)
                {
                    // Получаем метаданные файла
                    fileName = currentRequest.Metadata.FileName;
                    contentType = currentRequest.Metadata.ContentType;
                }
                else if (currentRequest.Data != null && currentRequest.Data.Length > 0)
                {
                    // Собираем данные файла
                    fileData = ConcatenateByteArrays(fileData, currentRequest.Data.ToByteArray());
                }
            }

            // Проверяем, что файл передан
            if (string.IsNullOrEmpty(fileName) || fileData.Length == 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "No file uploaded"));
            }

            var httpRequest = context.GetHttpContext().Request;
            var fileUrl = await _uploadService.UploadFileAsync(fileName, fileData, httpRequest.Scheme, httpRequest.Host.Host);

            return new Storage.GrpcContracts.Api.UploadFileResponse { FileUrl = fileUrl };
        }
        catch (Exception ex)
        {
            throw new RpcException(new Status(StatusCode.Internal, $"Error uploading file: {ex.Message}"));
        }
    }

    /// <summary>
    /// Объединение массивов байтов
    /// </summary>
    private static byte[] ConcatenateByteArrays(byte[] array1, byte[] array2)
    {
        var result = new byte[array1.Length + array2.Length];
        Buffer.BlockCopy(array1, 0, result, 0, array1.Length);
        Buffer.BlockCopy(array2, 0, result, array1.Length, array2.Length);
        return result;
    }
}