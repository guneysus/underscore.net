using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
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
        /// <param name="repeat"></param>
        /// <returns></returns>
        [Pure]
        public static string repeat(char c, int repeat)
        {
            return new string(c, repeat);
        }

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

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        [Pure]
        public static string concat(IEnumerable<char> vs)
        {
            return string.Concat(vs);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        [Pure]
        public static string concat(IEnumerable<string> vs)
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
        /// TODO #doc
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
        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        [Pure]
        public static string read(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, false, 4096))
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
        public static T New<T>() where T : new() => new T();
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
        /// Regular expression for matching an email address.
        /// </summary>
        /// <remarks>General Email Regex (RFC 5322 Official Standard) from emailregex.com.</remarks>
        const string _emailRegex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";

        #endregion
    }
}
