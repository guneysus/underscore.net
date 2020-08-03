using System;

namespace underscore.net
{
    public interface IDateTimeKindBuilder : IDateTimeBuilder
    {
        IDateTimeTimezoneBuilder Kind(DateTimeKind dateTimeKind);
    }
}