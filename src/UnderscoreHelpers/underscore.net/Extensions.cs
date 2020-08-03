using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace underscore.net
{

    public static class Extensions
    {
        #region Extension Methods
        public static IDateTimeYearBuilder calendar(
            this IDateTimeCalendarBuilder that,
            Calendar calendar) => that.Calendar(calendar);

        public static IDateTimeMonthBuilder year(
            this IDateTimeYearBuilder that,
            int year) => that.Year(year);

        public static IDateTimeDayBuilder month(
            this IDateTimeMonthBuilder that,
            int month) => that.Month(month);

        public static IDateTimeHourBuilder day(
            this IDateTimeDayBuilder that,
            int day) => that.Day(day);

        public static IDateTimeBuilderBuilder hour(
            this IDateTimeHourBuilder that,
            int hour) => that.Hour(hour);

        public static IDateTimeSecondBuilder minute(
            this IDateTimeBuilderBuilder that,
            int minute) => that.Minute(minute);

        public static IDateTimeMilisecondBuilder second(
            this IDateTimeSecondBuilder that,
            int second) => that.Second(second);

        public static IDateTimeKindBuilder milisecond(
            this IDateTimeMilisecondBuilder that,
            int milisecond) => that.Milisecond(milisecond);

        public static IDateTimeTimezoneBuilder kind(
            this IDateTimeKindBuilder that,
            DateTimeKind kind) => that.Kind(kind);

        public static IDateTimeBuilder timezone(
            this IDateTimeTimezoneBuilder that,
            TimeZoneInfo tz) => that.TimeZone(tz);

        public static DateTime build(this IDateTimeBuilder that) => that.Build();
        #endregion
    }
}
