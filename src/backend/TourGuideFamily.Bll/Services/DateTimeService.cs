using TourGuideFamily.Bll.Services.Interfaces;

namespace TourGuideFamily.Bll.Services;

public class DateTimeService : IDateTimeService
{
    public DateTimeOffset GetDateTimeOffset()
    {
        return DateTimeOffset.UtcNow;
    }
}