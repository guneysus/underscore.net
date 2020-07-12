using System;
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
        public static int timestamp(DateTime utcDateTime)
        {
            int result = (int)((DateTimeOffset)utcDateTime).ToUnixTimeSeconds();
            return result;
        }

        #endregion
    }
}
