using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourGuideFamily.Domain.Enums;

public enum СontactMethod
{
    [Description("Телеграм")]
    Telegram = 1,
    [Description("Вотсап")]
    WhatsApp = 2,
    [Description("Звонок")]
    Call = 3
}