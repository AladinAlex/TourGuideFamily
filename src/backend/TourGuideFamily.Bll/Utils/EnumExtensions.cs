using System.ComponentModel;
using System.Reflection;

namespace TourGuideFamily.Bll.Utils;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);

        return attribute?.Description ?? value.ToString();
    }
}
