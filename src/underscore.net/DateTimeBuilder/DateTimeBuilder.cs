using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace underscore.net
{
    public class DateTimeBuilder : IDateTimeBuilderBuilder
    {
        private Calendar _calendar;
        private int _day;
        private int _hours;
        private int _miliseconds;
        private int _minutes;
        private int _month;
        private int _seconds;
        private int _year;
        private DateTimeKind _kind;
        private TimeZoneInfo _timezone;

        DateTime IDateTimeBuilder.Build()
        {
            var _sourceDatetime = new DateTime(_year, _month, _day, _hours, _minutes, _seconds, _miliseconds, _calendar, _kind);
            var _convertedDatetime = TimeZoneInfo.ConvertTime(_sourceDatetime, _timezone);
            return _convertedDatetime;
        }

        public static IDateTimeCalendarBuilder Create()
        {
            return new DateTimeBuilder();
        }

        IDateTimeYearBuilder IDateTimeCalendarBuilder.Calendar(Calendar calendar)
        {
            this._calendar = calendar;
            return this;
        }

        IDateTimeHourBuilder IDateTimeDayBuilder.Day(int day)
        {
            _day = day;
            return this;
        }

        IDateTimeBuilderBuilder IDateTimeHourBuilder.Hour(int hour)
        {
            _hours = hour;
            return this;
        }

        IDateTimeTimezoneBuilder IDateTimeKindBuilder.Kind(DateTimeKind dateTimeKind)
        {
            _kind = dateTimeKind;
            return this;
        }

        IDateTimeKindBuilder IDateTimeMilisecondBuilder.Milisecond(int milisecond)
        {
            _miliseconds = milisecond;
            return this;
        }

        IDateTimeSecondBuilder IDateTimeMinuteBuilder.Minute(int minute)
        {
            _minutes = minute;
            return this;
        }

        IDateTimeDayBuilder IDateTimeMonthBuilder.Month(int month)
        {
            if (!(month >= 1 && month <= 12))
                throw new ArgumentOutOfRangeException(nameof(month));

            _month = month;
            return this;
        }

        IDateTimeMilisecondBuilder IDateTimeSecondBuilder.Second(int second)
        {
            _seconds = second;
            return this;
        }

        IDateTimeBuilder IDateTimeTimezoneBuilder.TimeZone(TimeZoneInfo timezone)
        {
            _timezone = timezone;
            return this;
        }

        IDateTimeMonthBuilder IDateTimeYearBuilder.Year(int year)
        {
            if (year <= 1900 || year >= 2100)
                throw new ArgumentOutOfRangeException(nameof(year));

            _year = year;
            return this;
        }
    }
}
