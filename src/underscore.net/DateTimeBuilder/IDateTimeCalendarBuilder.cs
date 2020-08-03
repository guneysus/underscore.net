using System.Globalization;

namespace underscore.net
{
    public interface IDateTimeCalendarBuilder
    {
        IDateTimeYearBuilder Calendar(Calendar calendar);
    }
}