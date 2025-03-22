using Microsoft.AspNetCore.Http;
using TourGuideFamily.Bll.Services.Interfaces;
using Grpc.Net.Client;
using Storage.GrpcContracts.Api;
using System.IO;

namespace TourGuideFamily.Bll.Services;

public class MultimediaService : IMultimediaService
{
    public MultimediaService()
    {

    }

    public async Task<string> UploadImageAsync(IFormFile file, CancellationToken token)
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:7017");
        var client = new UploadFileService.UploadFileServiceClient(channel);

        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var bytes = memoryStream.ToArray();

        var call = client.UploadFile();
        var metadata = new Metadata
        {
            FileName = file.FileName,
            ContentType = file.ContentType
        };
        await call.RequestStream.WriteAsync(new UploadFileRequest { Metadata = metadata });

        const int chunkSize = 8192;
        for (int i = 0; i < bytes.Length; i += chunkSize)
        {
            //var chunk = new byte[chunkSize];
            //Array.Copy(bytes, i, chunk, 0, chunkSize);
            //await call.RequestStream.WriteAsync(new UploadFileRequest { Data = Google.Protobuf.ByteString.CopyFrom(chunk) });
            await call.RequestStream.WriteAsync(new UploadFileRequest { Data = Google.Protobuf.ByteString.CopyFrom(bytes, i, chunkSize) });
        }

        await call.RequestStream.CompleteAsync();
        var response = await call.ResponseAsync;
        return response.FileUrl;
    }
}
