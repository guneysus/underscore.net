﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace underscore.net
{
    public partial class Underscore
    {

        #region Date Helpers
        /// <summary>
        ///  TODO #test
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Pure] public static DateTime date(DateTime date) => date.Date;

        /// <summary>
        /// from: https://stackoverflow.com/a/30412353/1766716
        /// TODO #doc
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <param name="cultureString"></param>
        /// <returns></returns>
        [Pure]
        public static DateTime datetime(string s, string format, string cultureString)
        {
            try
            {
                CultureInfo provider = CultureInfo.GetCultureInfo(cultureString);
                DateTime r = DateTime.ParseExact(s, format, provider);
                return r;
            }
            catch (FormatException)
            {
                // TODO
                throw;
            }
            catch (CultureNotFoundException)
            {
                // TODO
                throw; // Given Culture is not supported culture
            }
        }

        /// <summary>
        /// TODO TEST https://stackoverflow.com/a/26225951/1766716
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [Pure]
        public static DateTime datetime(long seconds, DateTimeKind dateTimeKind)
        {
            return DateTimeOffset.FromUnixTimeSeconds(seconds).DateTime;
            // TODO REVIEW return new DateTime(1970, 1, 1, 0, 0, 0, 0, dateTimeKind).AddSeconds(unixTimeStamp);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <returns></returns>
        [Pure]
        public static int timestamp(DateTime utcDateTime) => (int)((DateTimeOffset)utcDateTime).ToUnixTimeSeconds();

        /// <summary>
        /// from: https://stackoverflow.com/a/26225951/1766716
        /// TODO #test
        /// TOOD Test with TZs, local and UTC
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        [Pure]
        public static long miliseconds(DateTime datetime) => ((DateTimeOffset)datetime).ToUnixTimeMilliseconds();


        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Pure]
        public static DateTime lastday(DateTime date)
        {
            return new DateTime(date.Year,
                date.Month,
                DateTime.DaysInMonth(date.Year, date.Month)
                , 0, 0, 0, date.Kind);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Pure]
        public static DateTime lastday(int year, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 0, 0, 0, kind);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Pure]
        public static DateTime firstday(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0, 0, date.Kind);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Pure]
        public static DateTime firstday(int year, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, 0, kind);
        }


        #endregion

        #region Generators
        /// <summary>
        /// Get list of month names
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<string> months(CultureInfo cultureInfo)
        {
            for (int i = 1; i <= 12; i++)
                yield return cultureInfo.DateTimeFormat.GetMonthName(i);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <param name="startFrom"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<string> days(CultureInfo cultureInfo, DayOfWeek startFrom = DayOfWeek.Monday)
        {
            int start = (int)startFrom;

            for (int i = start; i < start + 7; i++)
            {
                yield return cultureInfo.DateTimeFormat.GetDayName((DayOfWeek)(i % 7));
            }
        }
        #endregion
    }
}
