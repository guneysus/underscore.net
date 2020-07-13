﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// TODO Regex overloads
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        [Pure]
        public static Func<string, IEnumerable<string>> matchor(string pattern)
        {
            return new Func<string, IEnumerable<string>>(input =>
            {
                var rgx = new Regex(pattern);
                // https://stackoverflow.com/a/12730562/1766716
                MatchCollection matchList = rgx.Matches(input);
                return matchList.Cast<Match>().Select(match => match.Value);
            });
        }

        /// <summary>
        /// Masks string with regex. 
        /// TODO: Regex overloads
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        [Pure]
        public static string mask(string input, string pattern, string replacement)
        {
            return new Regex(pattern).Replace(input, replacement);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Pure]
        public static int len(string s)
        {
            try
            {
                return s.Length;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        [Pure]
        public static int len<T>(IEnumerable<T> s)
        {
            return s.Count();
        }

        /// <summary>
        /// TODO #fn
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        [Pure]
        public static List<T> list<T>(params T[] args)
        {
            return args.ToList();
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        [Pure]
        public static Dictionary<K, V> dict<K, V>(IEnumerable<K> keys)
        {
            return keys.ToDictionary(x => x, __ => default(V));
        }


        /// <summary>
        /// TODO #Doc #FN
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        [Pure]
        public static Dictionary<TKey, TValue> dict<TKey, TValue>(params ValueTuple<TKey, TValue>[] items)
        {
            return items.ToDictionary(x => x.Item1, x => x.Item2);
        }


        /// <summary>
        /// TODO #fn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        [Pure]
        public static HashSet<T> hashset<T>(params T[] args)
        {
            return new HashSet<T>(args);
        }

        /// <summary>
        /// TODO #Doc #FN
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        [Pure]
        public static SortedDictionary<TKey, TValue> sortedDict<TKey, TValue>(params ValueTuple<TKey, TValue>[] items)
        {
            return new SortedDictionary<TKey, TValue>(items.ToDictionary(x => x.Item1, x => x.Item2));
        }

        /// <summary>
        /// TODO #fn
        /// TODO #doc
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="comparer"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        [Pure]
        public static SortedDictionary<TKey, TValue> sortedDict<TKey, TValue>(IComparer<TKey> comparer, params ValueTuple<TKey, TValue>[] items)
        {
            return new SortedDictionary<TKey, TValue>(items.ToDictionary(x => x.Item1, x => x.Item2), comparer);
        }


        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        [Pure]
        public static decimal Round(decimal number, int precision)
        {
            return Math.Round(number, precision);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="number"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        [Pure]
        public static double Round(double number, int precision)
        {
            return Math.Round(number, precision);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Pure]
        public static decimal Floor(decimal number)
        {
            return Math.Floor(number);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Pure]
        public static double Floor(double number)
        {
            return Math.Floor(number);
        }


        #region math
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="ir"></param>
        /// <param name="np"></param>
        /// <param name="pv"></param>
        /// <param name="fv"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Pure]
        public static decimal PMT(double ir, int np, decimal pv, decimal fv = 0, int type = 0)
        {
            /*
              from: https://stackoverflow.com/a/22385930/1766716
               * ir   - interest rate per month
               * np   - number of periods (months)
               * pv   - present value
               * fv   - future value
               * type - when the payments are due:
               *        0: end of the period, e.g. end of month (default)
               *        1: beginning of period
               */
            if (ir == 0)
            {
                return -(pv + fv) / np;
            }

            decimal pvif = (decimal)Math.Pow(1 + ir, np);
            decimal pmt = (-(decimal)ir * pv * (pvif + fv)) / (pvif - 1);

            if (type == 1)
            {
                pmt /= 1 + (decimal)ir;
            }

            return pmt;
        }
        #endregion

    }
}
