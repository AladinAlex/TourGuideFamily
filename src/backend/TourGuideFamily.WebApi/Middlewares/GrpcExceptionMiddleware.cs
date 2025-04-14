using Grpc.Core;
using System.Net;

namespace TourGuideFamily.WebApi.Middlewares;

public class GrpcExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GrpcExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RpcException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode switch
            {
                StatusCode.NotFound => (int)HttpStatusCode.NotFound,
                StatusCode.PermissionDenied => (int)HttpStatusCode.Forbidden,
                StatusCode.Unauthenticated => (int)HttpStatusCode.Unauthorized,
                StatusCode.InvalidArgument => (int)HttpStatusCode.BadRequest,
                StatusCode.DeadlineExceeded => (int)HttpStatusCode.GatewayTimeout,
                StatusCode.Unavailable => (int)HttpStatusCode.ServiceUnavailable,
                _ => (int)HttpStatusCode.InternalServerError
            };

            await context.Response.WriteAsJsonAsync(new
            {
                Error = "gRPC Error",
                Message = ex.Status.Detail,
                Status = ex.StatusCode.ToString()
            });
        }
    }
}
