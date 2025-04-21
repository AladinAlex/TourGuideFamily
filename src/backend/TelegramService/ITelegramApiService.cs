using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramService.Models;

namespace TelegramService;

public interface ITelegramApiService
{
    Task<TelegramServiceResponse> GetMe();
    Task<TelegramServiceResponse> SendMessage(long chat_id, string message);
}