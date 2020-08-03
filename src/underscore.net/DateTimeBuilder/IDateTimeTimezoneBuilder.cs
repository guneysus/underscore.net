using System;

namespace underscore.net
{
    public interface IDateTimeTimezoneBuilder : IDateTimeBuilder
    {
        IDateTimeBuilder TimeZone(TimeZoneInfo timezone);
    }
}