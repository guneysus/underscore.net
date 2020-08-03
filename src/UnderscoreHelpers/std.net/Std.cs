using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
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
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isbool(string v)
        {
            return bool.TryParse(lower(v), out bool result);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isdecimal(string v)
        {
            return decimal.TryParse(v, out decimal result);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnumber(string v, IFormatProvider formatProvider = null)
        {
            return isdecimal(v) || isfloat(v, formatProvider) || isinteger(v);
        }


        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="formatProvider"></param>
        /// <param name="numberStyles"></param>
        /// <returns></returns>
        [Pure]
        public static bool isfloat(string v, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            return float.TryParse(v, numberStyles, formatProvider, out float result);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool isinteger(string v)
        {
            return int.TryParse(v, out int result);
        }

#pragma warning disable RCS1163 // Unused parameter.
        /// <summary>
        /// TODO #Doc 
        /// TODO Implement formatProvider
        /// </summary>
        /// <param name="v"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [Pure]
        public static bool isnan(string v, IFormatProvider formatProvider = null)
#pragma warning restore RCS1163 // Unused parameter.
        {
            return !(isdecimal(v) || isfloat(v, null) || isinteger(v));
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

        [Pure]
        public static IEnumerable<KeyValuePair<TKey, TValue>> keyvalues<TKey, TValue>(params ValueTuple<TKey, TValue>[] items)
        {
            return items.Select(kv => new KeyValuePair<TKey, TValue>(kv.Item1, kv.Item2));
        }

        [Pure]
        public static IEnumerable<(TKey, TValue)> valuetuples<TKey, TValue>(params ValueTuple<TKey, TValue>[] items)
        {
            return items.Select(kv => (kv.Item1, kv.Item2));
        }

        [Pure]
        public static KeyValuePair<TKey, TValue> kv<TKey, TValue>(TKey key, TValue value)
        {
            return new KeyValuePair<TKey, TValue>(key, value);
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
        public static SortedDictionary<TKey, TValue> sorteddict<TKey, TValue>(params ValueTuple<TKey, TValue>[] items)
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
        public static SortedDictionary<TKey, TValue> sorteddict<TKey, TValue>(IComparer<TKey> comparer, params ValueTuple<TKey, TValue>[] items)
        {
            return new SortedDictionary<TKey, TValue>(items.ToDictionary(x => x.Item1, x => x.Item2), comparer);
        }

        public static Guid guid() => Guid.NewGuid();

        #region Bin
        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(sbyte value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(byte value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(short value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(ushort value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(int value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(uint value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(long value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static string bin(ulong value)
        {
            return Convert.ToString((long)value, 2);
        }
        #endregion

        [Pure]
        public static string RegexReplace(this string text, string pattern, string replacement)
        {
            string result = Regex.Replace(input: text, pattern: pattern, replacement: replacement, options: RegexOptions.CultureInvariant);
            return result;
        }

        [Pure]
        public static string compact(string v)
        {
            return RegexReplace(v, @"\s+", " ");
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string lower(string v)
        {
            Regex regexFindWords = new Regex("([A-Z][a-z0-9]+)+");
            Regex regexStrip = new Regex(@"\s+");
            string s = regexStrip.Replace(regexFindWords.Replace(v, m => " " + m.Groups[0].Value), " ").ToLower();
            return trim(s);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string upper(string v)
        {
            return v.ToUpper();
        }

        [Pure]
        public static string ChangeSpacesToHypens(string v)
        {
            return RegexReplace(v, @"\s", "-");
        }

        /// <summary>
        /// https://stackoverflow.com/a/249126/1766716
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [Pure]
        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        [Pure]
        public static string RemoveInvalidChars(string text)
        {
            const string pattern = @"[^a-z0-9\s-]";
            return RegexReplace(text, pattern, string.Empty);
        }

        [Pure]
        public static string RemoveExcept(string text, string pattern)
        {
            return RegexReplace(text, pattern, string.Empty);
        }

        [Pure]
        public static string join<T>(string seperator, IEnumerable<T> arr)
        {
            return string.Join(seperator, arr);
        }

        [Pure]
        public static string join<T>(IEnumerable<T> arr, string seperator) => join(seperator, arr);


        [Pure]
        public static T parse<T>(object value) where T : Enum
        { 
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)value;
            }

            throw new ArgumentException($"The value {value} is  not valid for the Enum {typeof(T)}");
        }

        [Pure]
        public static T parse<T>(string enumString) where T : struct
        {
            return (T)Enum.Parse(enumType: typeof(T), value: enumString, ignoreCase: true);
        }

        /// <summary>
        /// From http://stackoverflow.com/a/972323/1766716
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> values<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        [Pure]
        public static IEnumerable<string> names<T>() where T : struct
        {
            return Enum.GetNames(typeof(T)).ToArray();
        }

        #region Eq
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(bool value, bool other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(sbyte value, sbyte other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(byte value, byte other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(short value, short other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(ushort value, ushort other) => value.Equals(other);
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(int value, int other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(uint value, uint other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(long value, long other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(ulong value, ulong other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(float value, float other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(double value, double other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(decimal value, decimal other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(char value, char other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(Enum value, Enum other) => value.Equals(other);

        /// <summary>
        /// TODO See: https://docs.microsoft.com/en-us/dotnet/api/system.string.intern?view=netframework-4.8
        /// TODO #doc #test
        /// Use string.intern for performance 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool eq(string value, string other) => value.Equals(other);
        #endregion

        #region Gt
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(sbyte value, sbyte other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(byte value, byte other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(short value, short other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(ushort value, ushort other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(int value, int other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(uint value, uint other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(long value, long other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(ulong value, ulong other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(float value, float other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(double value, double other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gt(decimal value, decimal other) => value > other;
        #endregion

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        #region Gte
        [Pure]
        public static bool gte(sbyte value, sbyte other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(byte value, byte other) => value >= other;
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(short value, short other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(ushort value, ushort other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(int value, int other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(uint value, uint other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(long value, long other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(ulong value, ulong other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(float value, float other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(double value, double other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool gte(decimal value, decimal other) => value >= other;
        #endregion

        #region Lt
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(sbyte value, sbyte other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(byte value, byte other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(short value, short other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(ushort value, ushort other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(int value, int other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(uint value, uint other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(long value, long other) => value < other;
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(ulong value, ulong other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(float value, float other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(double value, double other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lt(decimal value, decimal other) => value < other;
        #endregion

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        #region Lte
        [Pure]
        public static bool lte(sbyte value, sbyte other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(byte value, byte other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(short value, short other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(ushort value, ushort other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(int value, int other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(uint value, uint other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(long value, long other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(ulong value, ulong other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(float value, float other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(double value, double other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool lte(decimal value, decimal other) => value <= other;
        #endregion

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static bool not(bool value)
        {
            return !value;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool and(bool value, bool other)
        {
            return value ^ other;
        }

        #region XOr
        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte xor(sbyte a, sbyte b)
        {
            return (sbyte)(a ^ b);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static byte xor(byte a, byte b)
        {
            return (byte)(a ^ b);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static short xor(short a, short b)
        {
            return (short)(a ^ b);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static ushort xor(ushort a, ushort b)
        {
            return (ushort)(a ^ b);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static int xor(int a, int b)
        {
            return a ^ b;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static uint xor(uint a, uint b)
        {
            return a ^ b;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static long xor(long a, long b)
        {
            return a ^ b;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static ulong xor(ulong a, ulong b)
        {
            return a ^ b;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static bool xor(bool a, bool b)
        {
            return a ^ b;
        }
        #endregion

        #region LOr
        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte lor(sbyte a, sbyte b)
        {
            return (sbyte)(a | b);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static byte lor(byte a, byte b)
        {
            return (byte)(a | b);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static short lor(short a, short b)
        {
            return (short)(a | b);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static ushort lor(ushort a, ushort b)
        {
            return (ushort)(a | b);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static int lor(int a, int b)
        {
            return a | b;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static uint lor(uint a, uint b)
        {
            return a | b;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static long lor(long a, long b)
        {
            return a | b;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static ulong lor(ulong a, ulong b)
        {
            return a | b;
        }

#pragma warning disable RCS1233 // Use short-circuiting operator.
#pragma warning disable S2178 // Short-circuit logic should be used in boolean contexts
        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Pure]
        public static bool lor(bool a, bool b)
        {
            return a | b;
        }
#pragma warning restore S2178 // Short-circuit logic should be used in boolean contexts
#pragma warning restore RCS1233 // Use short-circuiting operator.
        #endregion

        #region add
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte incr(sbyte augend, sbyte addend = 1)
        {
            return (sbyte)(augend + addend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static byte incr(byte augend, byte addend = 1)
        {
            return (byte)(augend + addend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static short incr(short augend, short addend = 1)
        {
            return (short)(augend + addend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static ushort incr(ushort augend, ushort addend = 1)
        {
            return (ushort)(augend + addend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static int incr(int augend, int addend = 1)
        {
            return augend + addend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static uint incr(uint augend, uint addend = 1)
        {
            return augend + addend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static long incr(long augend, long addend = 1)
        {
            return augend + addend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static ulong incr(ulong augend, ulong addend = 1)
        {
            return augend + addend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static float incr(float augend, float addend = 1)
        {
            return augend + addend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static double incr(double augend, double addend = 1)
        {
            return augend + addend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="augend"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [Pure]
        public static decimal incr(decimal augend, decimal addend = 1)
        {
            return augend + addend;
        }

        #endregion

        #region Divide
        [Pure]
        public static sbyte divide(sbyte dividend, sbyte divisor)
        {
            return (sbyte)(dividend / divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static byte divide(byte dividend, byte divisor)
        {
            return (byte)(dividend / divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static short divide(short dividend, short divisor)
        {
            return (short)(dividend / divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static ushort divide(ushort dividend, ushort divisor)
        {
            return (ushort)(dividend / divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static int divide(int dividend, int divisor)
        {
            return dividend / divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static uint divide(uint dividend, uint divisor)
        {
            return dividend / divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static long divide(long dividend, long divisor)
        {
            return dividend / divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static ulong divide(ulong dividend, ulong divisor)
        {
            return dividend / divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static float divide(float dividend, float divisor)
        {
            return dividend / divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static double divide(double dividend, double divisor)
        {
            return dividend / divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static decimal divide(decimal dividend, decimal divisor)
        {
            return dividend / divisor;
        }
        #endregion

        #region Subtract
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte decr(sbyte minuend, sbyte subtrahend)
        {
            return (sbyte)(minuend - subtrahend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static byte decr(byte minuend, byte subtrahend = 1)
        {
            return (byte)(minuend - subtrahend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static short decr(short minuend, short subtrahend = 1)
        {
            return (short)(minuend - subtrahend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static ushort decr(ushort minuend, ushort subtrahend = 1)
        {
            return (ushort)(minuend - subtrahend);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static int decr(int minuend, int subtrahend = 1)
        {
            return minuend - subtrahend;
        }

        [Pure]
        public static uint decr(uint minuend, uint subtrahend = 1)
        {
            return minuend - subtrahend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static long decr(long minuend, long subtrahend = 1)
        {
            return minuend - subtrahend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static ulong decr(ulong minuend, ulong subtrahend = 1)
        {
            return minuend - subtrahend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static float decr(float minuend, float subtrahend = 1)
        {
            return minuend - subtrahend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static double decr(double minuend, double subtrahend = 1)
        {
            return minuend - subtrahend;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="minuend"></param>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        [Pure]
        public static decimal decr(decimal minuend, decimal subtrahend)
        {
            return minuend - subtrahend;
        }
        #endregion

        #region Multiply
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte multiply(sbyte multiplier, sbyte multiplicand)
        {
            return (sbyte)(multiplier * multiplicand);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static byte multiply(byte multiplier, byte multiplicand)
        {
            return (byte)(multiplier * multiplicand);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static short multiply(short multiplier, short multiplicand)
        {
            return (short)(multiplier * multiplicand);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static ushort multiply(ushort multiplier, ushort multiplicand)
        {
            return (ushort)(multiplier * multiplicand);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static int multiply(int multiplier, int multiplicand)
        {
            return multiplier * multiplicand;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static uint multiply(uint multiplier, uint multiplicand)
        {
            return multiplier * multiplicand;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static long multiply(long multiplier, long multiplicand)
        {
            return multiplier * multiplicand;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static ulong multiply(ulong multiplier, ulong multiplicand)
        {
            return multiplier * multiplicand;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static float multiply(float multiplier, float multiplicand)
        {
            return multiplier * multiplicand;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static double multiply(double multiplier, double multiplicand)
        {
            return multiplier * multiplicand;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="multiplicand"></param>
        /// <returns></returns>
        [Pure]
        public static decimal multiply(decimal multiplier, decimal multiplicand)
        {
            return multiplier * multiplicand;
        }
        #endregion

        #region Remainder
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte remainder(sbyte dividend, sbyte divisor)
        {
            return (sbyte)(dividend % divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static byte remainder(byte dividend, byte divisor)
        {
            return (byte)(dividend % divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static short remainder(short dividend, short divisor)
        {
            return (short)(dividend % divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static ushort remainder(ushort dividend, ushort divisor)
        {
            return (ushort)(dividend % divisor);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static int remainder(int dividend, int divisor)
        {
            return dividend % divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static uint remainder(uint dividend, uint divisor)
        {
            return dividend % divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static long remainder(long dividend, long divisor)
        {
            return dividend % divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static ulong remainder(ulong dividend, ulong divisor)
        {
            return dividend % divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static float remainder(float dividend, float divisor)
        {
            return dividend % divisor;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static double remainder(double dividend, double divisor)
        {
            return dividend % divisor;
        }

        /// <summary>
        /// TODO #doc 
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [Pure]
        public static decimal remainder(decimal dividend, decimal divisor)
        {
            return dividend % divisor;
        }

        #endregion


        #region ShiftLeft
        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte sleft(sbyte value, int count)
        {
            return (sbyte)(value << count);
        }

        [Pure]
        public static byte sleft(byte value, int count)
        {
            return (byte)(value << count);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static short sleft(short value, int count)
        {
            return (short)(value << count);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static ushort sleft(ushort value, int count)
        {
            return (ushort)(value << count);
        }

        [Pure]
        public static int sleft(int value, int count)
        {
            return value << count;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static uint sleft(uint value, int count)
        {
            return value << count;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static long sleft(long value, int count)
        {
            return value << count;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static ulong sleft(ulong value, int count)
        {
            return value << count;
        }
        #endregion

        #region ShiftRight
        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static sbyte sright(sbyte value, int count)
        {
            return (sbyte)(value >> count);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static byte sright(byte value, int count)
        {
            return (byte)(value >> count);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static short sright(short value, int count)
        {
            return (short)(value >> count);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static ushort sright(ushort value, int count)
        {
            return (ushort)(value >> count);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static int sright(int value, int count)
        {
            return value >> count;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static uint sright(uint value, int count)
        {
            return value >> count;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static long sright(long value, int count)
        {
            return value >> count;
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Pure]
        public static ulong sright(ulong value, int count)
        {
            return value >> count;
        }
        #endregion

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        [Pure]
        public static decimal round(decimal number, int precision)
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
        public static double round(double number, int precision)
        {
            return Math.Round(number, precision);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Pure]
        public static decimal floor(decimal number)
        {
            return Math.Floor(number);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Pure]
        public static double floor(double number)
        {
            return Math.Floor(number);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        #region InRange
        [Pure]
        public static bool inrange(sbyte number, sbyte start, sbyte end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(sbyte number, sbyte end)
        {
            return 0 <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(byte number, byte start, byte end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(byte number, byte end)
        {
            return number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(short number, short start, short end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(short number, short end)
        {
            return 0 <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(ushort number, ushort start, ushort end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(ushort number, ushort end)
        {
            return number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(int number, int start, int end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(int number, int end)
        {
            return 0 <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(uint number, uint start, uint end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(uint number, uint end)
        {
            return number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(long number, long start, long end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(long number, long end)
        {
            return 0 <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(ulong number, ulong start, ulong end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(ulong number, ulong end)
        {
            return number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(float number, float start, float end)
        {
            return start <= number && number <= end;
        }

        [Pure]
        public static bool inrange(float number, float end)
        {
            return 0 <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(double number, double start, double end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(double number, double end)
        {
            return 0 <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(decimal number, decimal start, decimal end)
        {
            return start <= number && number <= end;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [Pure]
        public static bool inrange(decimal number, decimal end)
        {
            return 0 <= number && number <= end;
        }

        #endregion

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Pure]
        public static int integer(string s)
        {
            return isinteger(s) ? int.Parse(s) : default(int);
        }
    }
}

