namespace TelegramService.Models;

public class TelegramServiceResponse
{
    public bool Success { get; set; } = true!;
    public object Data { get; set; }
    public string Error { get; set; }
}