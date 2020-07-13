using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace std.net
{
    public static class Std
    {
        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        [Pure]
        public static string pad(string v, int pad)
        {
            const char padWith = ' ';
            string result = repeat(padWith, (pad - v.Length) / 2);
            string remainder = repeat(padWith, pad - v.Length - result.Length);
            return result + v + remainder;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pad"></param>
        /// <param name="padWith"></param>
        /// <returns></returns>
        [Pure]
        public static string pad(string v, int pad, string padWith)
        {
            string result = repeat(padWith, (pad - v.Length) / padWith.Length / 2);
            string remainder = concat(padWith.Take(pad - v.Length - (2 * result.Length)));
            return result + v + result + remainder;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pad"></param>
        /// <param name="padWith"></param>
        /// <returns></returns>
        [Pure]
        public static string padright(string v, int pad, string padWith)
        {
            string result = v + repeat(padWith, (pad - v.Length) / padWith.Length);
            string remainder = concat(padWith.Take(pad - result.Length));
            return result + remainder;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        [Pure]
        public static string padright(string v, int pad)
        {
            return v + repeat(' ', pad - v.Length);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pad"></param>
        /// <param name="padWith"></param>
        /// <returns></returns>
        [Pure]
        public static string padleft(string v, int pad, string padWith)
        {
            string result = repeat(padWith, (pad - v.Length) / padWith.Length);
            string remainder = concat(padWith.Take(pad - v.Length - result.Length));
            return result + remainder + v;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pad"></param>
        /// <param name="padWith"></param>
        /// <returns></returns>
        [Pure]
        public static string padleft(string v, int pad, char padWith)
        {
            string result = repeat(padWith, pad - v.Length) + v;
            return result;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        [Pure]
        public static string padleft(string v, int pad)
        {
            return repeat(' ', pad - v.Length) + v;
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
        /// <param name="v"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
        [Pure]
        public static string trim(string v, string trim)
        {
            if (isnull(v))
            {
                throw new ArgumentNullException(nameof(v));
            }

            return v.Trim(trim.ToCharArray());
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string trim(string v)
        {
            if (isnull(v))
            {
                throw new ArgumentNullException(nameof(v));
            }

            return v.Trim();
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
        [Pure]
        public static string trimleft(string v, string trim)
        {
            if (isnull(v))
            {
                throw new ArgumentNullException(nameof(v));
            }

            return v.TrimStart(trim.ToCharArray());
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string trimleft(string v)
        {
            if (isnull(v))
            {
                throw new ArgumentNullException(nameof(v));
            }

            return v.TrimStart();
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string trimright(string v)
        {
            if (isnull(v))
            {
                throw new ArgumentNullException(nameof(v));
            }

            return v.TrimEnd();
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
        [Pure]
        public static string trimright(string v, string trim)
        {
            return v.TrimEnd(trim.ToCharArray());
        }


        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(decimal? v)
        {
            return !v.HasValue;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(double? v)
        {
            return !v.HasValue;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(float? v)
        {
            return !v.HasValue;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(string v)
        {
            return v == default(string);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(DateTime? v)
        {
            return !v.HasValue;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(bool? v)
        {
            return !v.HasValue;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(int? v)
        {
            return !v.HasValue;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnull(Guid? v)
        {
            return !v.HasValue;
        }



        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<char> truncate(string s, int length, string suffix = "…")
        {
            return concat(s.Take(length - 1)) + suffix;
        }
    }
}
