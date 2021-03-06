﻿using System;
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
        public static DateTime datetimeunix(long seconds, DateTimeKind dateTimeKind)
        {
            return DateTimeOffset.FromUnixTimeSeconds(seconds).DateTime;
            // TODO REVIEW return new DateTime(1970, 1, 1, 0, 0, 0, 0, dateTimeKind).AddSeconds(unixTimeStamp);
        }

        [Pure]
        public static DateTime datetimeunix(DateTimeKind dateTimeKind, long seconds) => datetimeunix(seconds, dateTimeKind);

        #region TODO datetime and timespan factory methods
        public static IDateTimeCalendarBuilder datetime() => SingletonFullyLazy<DateTimeBuilder>.Instance;

        public static DateTime datetime(long ticks) => new DateTime(ticks);
        public static DateTime datetime(long ticks, DateTimeKind kind) => new DateTime(ticks, kind);
        public static DateTime datetime(DateTimeKind kind, long ticks) => datetime(ticks, kind);
        public static DateTime datetime(int year, int month, int day) => new DateTime(year, month, day);
        public static DateTime datetime(int year, int month, int day, Calendar calendar) => new DateTime(year, month, day, calendar);
        public static DateTime datetime(int year, int month, int day, int hour, int minute, int second) => new DateTime(year, month, day, hour, minute, second);
        public static DateTime datetime(int year, int month, int day, int hour, int minute, int second, Calendar calendar)
        {
            return new DateTime(year, month, day, hour, minute, second, calendar);
        }

        public static DateTime datetime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
        {
            return new DateTime(year, month, day, hour, minute, second, kind);
        }

        public static DateTime datetime(int year, int month, int day, int hour, int minute, int second, int milisecond)
        {
            return new DateTime(year, month, day, hour, minute, second, milisecond);
        }

        public static DateTime datetime(int year, int month, int day, int hour, int minute, int second, int milisecond, Calendar calendar)
        {
            return new DateTime(year, month, day, hour, minute, second, milisecond, calendar);
        }

        public static DateTime datetime(int year, int month, int day, int hour, int minute, int second, int milisecond, DateTimeKind kind)
        {
            return new DateTime(year, month, day, hour, minute, second, milisecond, kind);
        }

        public static DateTime datetime(int year, int month, int day, int hour, int minute, int second, int milisecond, Calendar calendar, DateTimeKind kind)
        {
            return new DateTime(year, month, day, hour, minute, milisecond, second, calendar, kind);
        }

        public static TimeSpan days(double day) => TimeSpan.FromDays(day);
        public static TimeSpan hours(double hour) => TimeSpan.FromHours(hour);
        public static TimeSpan minutes(double minute) => TimeSpan.FromMinutes(minute);
        public static TimeSpan seconds(double second) => TimeSpan.FromSeconds(second);
        public static TimeSpan miliseconds(double milisecond) => TimeSpan.FromMilliseconds(milisecond);
        public static TimeSpan ticks(long tick) => TimeSpan.FromTicks(tick);
        #endregion

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Pure]
        public static int timestamp(DateTime date) => (int)((DateTimeOffset)date).ToUnixTimeSeconds();

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
        /// Get list of month names
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<string> months(string cultureName)
        {
            return months(CultureInfo.GetCultureInfo(cultureName));
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<string> days(CultureInfo cultureInfo, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            int start = (int)firstDayOfWeek;

            for (int i = start; i < start + 7; i++)
            {
                yield return cultureInfo.DateTimeFormat.GetDayName((DayOfWeek)(i % 7));
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<string> days(string cultureName, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return days(CultureInfo.GetCultureInfo(cultureName), firstDayOfWeek);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<int> range(int count) => Enumerable.Range(0, count);

        [Pure]
        public static IEnumerable<int> range(int start, int end)
        {
            int count = end - start + 1;
            return Enumerable.Range(start, count);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<int> range(int start, int end, int step)
        {
            if (step == decimal.Zero) throw new ArgumentOutOfRangeException(nameof(step));

            if (end < 0 && step < 0)
            {
                while (start >= end)
                {
                    yield return start;
                    start += step;
                }
            }
            else
            {
                while ((step < 0 && start >= end) || start <= end)
                {
                    yield return start;
                    start += step;
                }
            }
        }

        /// <summary>
        /// TODO #doc
        /// TODO Improve with yield return
        /// </summary>
        /// <param name="end"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<int> rrange(int end, int start = 0)
        {
            int current = end;
            //List<int> result = new List<int>();

            while (current > start)
            {
                current--;
                yield return current;
                //result.Add(current);
            }

            //return result;
            yield break;
        }


        #endregion

        #region Hash tools
        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [Pure]
        public static string sha512(string source)
        {
            using (SHA512 hasher = SHA512.Create())
            {
                byte[] sourceBytes = utf8bytearray(source);
                byte[] hashBytes = hasher.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes);
                return strip(hash, "-");
            }
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [Pure]
        public static string sha256(string source)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] sourceBytes = utf8bytearray(source);
                byte[] hashBytes = hasher.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes);
                return strip(hash, "-");
            }
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [Pure]
        public static string sha1(string source)
        {
#pragma warning disable SG0006 // Weak hashing function
            using (SHA1 hasher = SHA1.Create())
#pragma warning restore SG0006 // Weak hashing function
            {
                byte[] sourceBytes = utf8bytearray(source);
                byte[] hashBytes = hasher.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes);
                return strip(hash, "-");
            }
        }

        [Pure]
        public static byte[] sha1(byte[] source)
        {
            using (SHA1 hasher = SHA1.Create())
                return hasher.ComputeHash(source);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [Pure]
        public static string sha384(string source)
        {
            using (SHA384 hasher = SHA384.Create())
            {
                byte[] sourceBytes = utf8bytearray(source);
                byte[] hashBytes = hasher.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes);
                return strip(hash, "-");
            }
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [Pure]
        public static string md5(string source)
        {
#pragma warning disable SG0006 // Weak hashing function
            using (MD5 hasher = MD5.Create())
            {
#pragma warning restore SG0006 // Weak hashing function
                return strip(BitConverter.ToString(hasher.ComputeHash(utf8bytearray(source))), "-");
            }
        }
        #endregion

        #region Core
        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Pure]
        public static byte[] utf8bytearray(string s) => Encoding.UTF8.GetBytes(s);

        /// <summary>
        /// TODO #doc
        /// https://stackoverflow.com/a/39666660/1766716
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Pure]
        public static T clone<T>(T obj)
        {
            MethodInfo inst = obj
                .GetType()
                .GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        [Pure]
        public static IList<T> clone<T>(IList<T> input)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                return (IList<T>)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        [Pure]
        public static ICollection<T> clone<T>(ICollection<T> input)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                return (ICollection<T>)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> clone<T>(IEnumerable<T> input)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                return (IEnumerable<T>)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        [Pure]
        public static IReadOnlyCollection<T> clone<T>(IReadOnlyCollection<T> input)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                return (IReadOnlyCollection<T>)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        [Pure]
        public static IReadOnlyList<T> clone<T>(IReadOnlyList<T> input)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                return (IReadOnlyList<T>)formatter.Deserialize(stream);
            }
        }

        #endregion

        #region String Tools

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        [Pure]
        public static string strip(string source, string s) => source.Replace(s, string.Empty);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string capitalize(string v)
        {
            var sb = new StringBuilder();

            if (v is null)
                throw new ArgumentNullException(nameof(v));

            if (v == string.Empty)
                return v;

            var chars = v.ToCharArray();

            sb.Append(Char.ToUpper(chars[0]));

            foreach (var item in chars.Skip(1))
                sb.Append(Char.ToLower(item));

            return sb.ToString();
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string deburr(string v)
        {
            // https://stackoverflow.com/a/3288164/1766716
            return new string(v
                .Normalize(NormalizationForm.FormD)
                .ToCharArray()
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string escape(string v)
        {
            return HttpUtility.HtmlEncode(v);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string unescape(string v)
        {
            return HttpUtility.HtmlDecode(v);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        [Pure]
        public static string repeat(char c, int times)
        {
            return new string(c, times);
        }

        [Pure]
        public static string repeat(int times, char c) => repeat(c, times);

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="repeat"></param>
        /// <returns></returns>
        [Pure]
        public static string repeat(string v, int repeat)
        {
            return string.Concat(Enumerable.Repeat(v, repeat));
        }

        [Pure]
        public static string repeat(int times, string v) => repeat(v, times);

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        [Pure]
        public static string concat(params char[] vs)
        {
            return string.Concat(vs);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        [Pure]
        public static string concat(params string[] vs)
        {
            var sb = new StringBuilder();
            foreach (var item in vs)
                sb.Append(item);

            return sb.ToString();
        }

        /// <summary>
        /// https://stackoverflow.com/a/311179/1766716
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<char> hex(byte[] byteArray)
        {
            StringBuilder hex = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
                _ = hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Pure]
        public static string base64decode(string s)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(s));
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Pure]
        public static string base64encode(string message)
        {
            return Convert.ToBase64String(utf8bytearray(message));
        }

        #endregion

        #region Random Value Generators

        /// <summary>
        /// DO NOT USE FOR CRYPTOGRAPHIC SCENARIOS
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static byte[] random(int count)
        {
            Random rnd = new Random();
            byte[] buff = new byte[count];
            rnd.NextBytes(buff);
            return buff;
        }
        #endregion

        #region Stream Helpers

        [Pure]
        public static string read(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using StreamReader reader = new StreamReader(
                stream,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false);
            return reader.ReadToEnd();
        }

        [Pure]
        public static string read(Stream stream, Encoding encoding)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using StreamReader reader = new StreamReader(
                stream,
                encoding: encoding,
                detectEncodingFromByteOrderMarks: false);
            return reader.ReadToEnd();
        }

        #endregion

        #region Gzip
        /// <summary>
        /// https://stackoverflow.com/a/7343623/1766716
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [Pure]
        public static byte[] compress(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    copy(msi, gs);
                }

                return mso.ToArray();
            }
        }

        [Pure]
        public static string decompress(byte[] data)
        {
            using (var msi = new MemoryStream(data))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                    copy(gs, mso);

                return read(mso);
            }
        }

        /// <summary>
        /// https://stackoverflow.com/a/7343623/1766716
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        [Pure]
        public static void copy(Stream source, Stream destination)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = source.Read(bytes, 0, bytes.Length)) != 0)
            {
                destination.Write(bytes, 0, cnt);
            }
        }
        #endregion

        #region Regex
        /// <summary>
        /// TODO #doc
        /// TODO Implement timeout to avoid DDOS
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [Pure]
        public static Func<string, IEnumerable<string>> extractor(string pattern, RegexOptions options = RegexOptions.Multiline | RegexOptions.Compiled)
        {
            return new Func<string, IEnumerable<string>>(text =>
            {
                // https://stackoverflow.com/a/12730562/1766716
                Regex regex = new Regex(pattern, options);
                MatchCollection matchList = regex.Matches(text);
                return matchList.Cast<Match>().Select(match => match.Value).ToList();
            });
        }
        #endregion

        #region Reflection
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T create<T>() where T : new() => new T();
        #endregion

        #region Validators
        /// <summary>
        /// Determines whether a string is a valid email address.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns><c>true</c> for a valid email address; otherwise, <c>false</c>.</returns>
        [Pure]
        public static bool email(string str) => Regex.IsMatch(str, _emailRegex);

        /// <summary>
        /// Determines whether a string is a valid phone number.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns><c>true</c> for a valid phone number; otherwise, <c>false</c>.</returns>
        [Pure]
        public static bool phone(string str) => Regex.IsMatch(str, _phoneNumberRegex);

        [Pure]
        public static bool ip(string str) => Regex.IsMatch(str, _ipRegex);

        /// <summary>
        /// Regular expression for matching an email address.
        /// </summary>
        /// <remarks>General Email Regex (RFC 5322 Official Standard) from emailregex.com.</remarks>
        const string _emailRegex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";

        /// <summary>
        /// Regular expression for matching a phone number.
        /// </summary>
        const string _phoneNumberRegex = @"^[+]?(\d{1,3})?[\s.-]?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{2}[\s.-]?\d{2}$";

        const string _ipRegex = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        /// <summary>
        /// TODO #doc
        /// </summary>
        private static string[] BOOLEAN_VALUES => new string[] { "1", "yes", "true", "on", "checked" };

        #endregion

        #region Type Convert

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static bool boolean(string value) => boolean(value, BOOLEAN_VALUES);


        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trueValues"></param>
        /// <returns></returns>
        [Pure]
        public static bool boolean(string value, params string[] trueValues) => trueValues.Contains(value.ToLowerInvariant());
        #endregion

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<string> words(string v)
        {
            // https://stackoverflow.com/a/12730562/1766716
            Regex regex = new Regex(@"\w+");
            MatchCollection matchList = regex.Matches(v);
            return matchList.Cast<Match>().Select(match => match.Value).ToList();
        }

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string text(decimal value)
        {
            return value.ToString();
        }

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [Pure]
        public static string text(decimal value, IFormatProvider formatProvider)
        {
            return value.ToString(formatProvider);
        }

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        [Pure]
        public static string text(decimal value, string format)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [Pure]
        public static string text(decimal value, string format, IFormatProvider formatProvider)
        {
            return value.ToString(format, formatProvider);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T @default<T>() => default;

        [Pure]
        public static T @default<T>(T obj) => default;

        /// <summary>
        /// TODO #Doc #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        [Pure]
        public static Type type<T>() => typeof(T);

        [Pure]
        public static Type type<T>(T obj) => typeof(T);


        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure] public static T min<T>() where T : struct => (T)typeof(T).GetField("MinValue").GetValue(null);
        [Pure] public static T min<T>(T obj) where T : struct => (T)typeof(T).GetField("MinValue").GetValue(null);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure] public static T max<T>() where T : struct => (T)typeof(T).GetField("MaxValue").GetValue(null);
        [Pure] public static T max<T>(T obj) where T : struct => (T)typeof(T).GetField("MaxValue").GetValue(null);
    }
}
