namespace TelegramService.Models;

public class SendMessageRequest
{
    public long chat_id { get; set; }
    public string text { get; set; }
}