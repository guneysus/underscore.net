using System;

namespace underscore.net
{
    public interface IDateTimeBuilderBuilder :
        IDateTimeYearBuilder,
        IDateTimeMonthBuilder,
        IDateTimeDayBuilder,
        IDateTimeHourBuilder,
        IDateTimeMinuteBuilder,
        IDateTimeSecondBuilder,
        IDateTimeMilisecondBuilder,
        IDateTimeTimezoneBuilder,
        IDateTimeCalendarBuilder,
        IDateTimeKindBuilder,
        IDateTimeBuilder
    {
    }

}
