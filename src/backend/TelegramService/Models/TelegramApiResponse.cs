using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramService.Models;

public class TelegramApiResponse
{
    public bool ok { get; set; }
    public int? error_code { get; set; }
    public string description { get; set; }
    public object result { get; set; }

    public string GetError()
    {
        if (!this.ok && this.error_code.HasValue && !string.IsNullOrWhiteSpace(description))
            return "ok: " + this.ok + "; error_code:" + this.error_code + "; description: " + description;
        else
            return "";
    }
}