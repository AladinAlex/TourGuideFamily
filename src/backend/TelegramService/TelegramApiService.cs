using System.Text;
using System.Text.Json;
using System.Web;
using System.Net.Http;
using TelegramService.Models;

namespace TelegramService;

public class TelegramApiService : ITelegramApiService
{
    readonly HttpClient httpClient;
    //readonly string authRequest;
    readonly string encodedToken;
    public TelegramApiService(string telegramApi, string token)
    {
        httpClient = new HttpClient
        {
            BaseAddress = new Uri(telegramApi),
        };
        //authRequest = "bot" + token;
        encodedToken = HttpUtility.UrlEncode("bot" + token);
    }
    public async Task<TelegramServiceResponse> GetMe()
    {
        TelegramServiceResponse response = new();
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, encodedToken + "/getMe");
        HttpResponseMessage httpResponseMessage = new();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        try
        {
            httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TelegramApiResponse>(contentStream, options);
            if (result != null)
            {
                if (result.ok)
                    response.Data = result?.result.ToString();
                else
                {
                    response.Error = result.GetError();
                    response.Success = false;
                }
            }
            else
            {
                response.Error = "Пустой ответ";
                response.Success = false;
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Error += ex.Message + ex.Source + ex.StackTrace;
        }
        return response;
    }

    public async Task<TelegramServiceResponse> SendMessage(long chat_id, string message)
    {
        TelegramServiceResponse response = new();
        SendMessageRequest request = new SendMessageRequest()
        {
            chat_id = chat_id,
            text = message
        };
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, encodedToken + "/sendMessage")
        {
            Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"),
        };

        HttpResponseMessage httpResponseMessage = new();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        try
        {
            httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TelegramApiResponse>(contentStream, options);
            if (result != null)
            {
                if (result.ok)
                    response.Data = result?.result.ToString();
                else
                {
                    response.Error = result.GetError();
                    response.Success = false;
                }
            }
            else
            {
                response.Error = "Пустой ответ";
                response.Success = false;
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Error += ex.Message + ex.Source + ex.StackTrace;
        }
        return response;
    }
}