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
        public static bool IsBool(string v)
        {
            return bool.TryParse(LowerCase(v), out bool result);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool IsDecimal(string v)
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
        public static bool IsNumber(string v, IFormatProvider formatProvider = null)
        {
            return IsDecimal(v) || IsFloat(v, formatProvider) || IsInteger(v);
        }


        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="formatProvider"></param>
        /// <param name="numberStyles"></param>
        /// <returns></returns>
        [Pure]
        public static bool IsFloat(string v, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            return float.TryParse(v, numberStyles, formatProvider, out float result);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static bool IsInteger(string v)
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
        public static bool IsNan(string v, IFormatProvider formatProvider = null)
#pragma warning restore RCS1163 // Unused parameter.
        {
            return !(IsDecimal(v) || IsFloat(v, null) || IsInteger(v));
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
        public static string CompactSpaces(string v)
        {
            return RegexReplace(v, @"\s+", " ");
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string LowerCase(string v)
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
        public static string UpperCase(string v)
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
        public static bool Eq(bool value, bool other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(sbyte value, sbyte other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(byte value, byte other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(short value, short other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(ushort value, ushort other) => value.Equals(other);
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(int value, int other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(uint value, uint other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(long value, long other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(ulong value, ulong other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(float value, float other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(double value, double other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(decimal value, decimal other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(char value, char other) => value.Equals(other);

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(Enum value, Enum other) => value.Equals(other);

        /// <summary>
        /// TODO See: https://docs.microsoft.com/en-us/dotnet/api/system.string.intern?view=netframework-4.8
        /// TODO #doc #test
        /// Use string.intern for performance 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Eq(string value, string other) => value.Equals(other);
        #endregion

        #region Gt
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(sbyte value, sbyte other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(byte value, byte other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(short value, short other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(ushort value, ushort other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(int value, int other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(uint value, uint other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(long value, long other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(ulong value, ulong other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(float value, float other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(double value, double other) => value > other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gt(decimal value, decimal other) => value > other;
        #endregion

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        #region Gte
        [Pure]
        public static bool Gte(sbyte value, sbyte other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(byte value, byte other) => value >= other;
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(short value, short other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(ushort value, ushort other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(int value, int other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(uint value, uint other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(long value, long other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(ulong value, ulong other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(float value, float other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(double value, double other) => value >= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Gte(decimal value, decimal other) => value >= other;
        #endregion

        #region Lt
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(sbyte value, sbyte other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(byte value, byte other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(short value, short other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(ushort value, ushort other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(int value, int other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(uint value, uint other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(long value, long other) => value < other;
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(ulong value, ulong other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(float value, float other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(double value, double other) => value < other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lt(decimal value, decimal other) => value < other;
        #endregion

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        #region Lte
        [Pure]
        public static bool Lte(sbyte value, sbyte other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(byte value, byte other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(short value, short other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(ushort value, ushort other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(int value, int other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(uint value, uint other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(long value, long other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(ulong value, ulong other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(float value, float other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(double value, double other) => value <= other;

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        [Pure]
        public static bool Lte(decimal value, decimal other) => value <= other;
        #endregion

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Pure]
        public static bool Not(bool value)
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
        public static bool And(bool value, bool other)
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
        public static sbyte XOr(sbyte a, sbyte b)
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
        public static byte XOr(byte a, byte b)
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
        public static short XOr(short a, short b)
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
        public static ushort XOr(ushort a, ushort b)
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
        public static int XOr(int a, int b)
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
        public static uint XOr(uint a, uint b)
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
        public static long XOr(long a, long b)
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
        public static ulong XOr(ulong a, ulong b)
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
        public static bool XOr(bool a, bool b)
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
        public static sbyte LOr(sbyte a, sbyte b)
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
        public static byte LOr(byte a, byte b)
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
        public static short LOr(short a, short b)
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
        public static ushort LOr(ushort a, ushort b)
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
        public static int LOr(int a, int b)
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
        public static uint LOr(uint a, uint b)
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
        public static long LOr(long a, long b)
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
        public static ulong LOr(ulong a, ulong b)
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
        public static bool LOr(bool a, bool b)
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
        public static sbyte Incr(sbyte augend, sbyte addend = 1)
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
        public static byte Incr(byte augend, byte addend = 1)
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
        public static short Incr(short augend, short addend = 1)
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
        public static ushort Incr(ushort augend, ushort addend = 1)
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
        public static int Incr(int augend, int addend = 1)
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
        public static uint Incr(uint augend, uint addend = 1)
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
        public static long Incr(long augend, long addend = 1)
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
        public static ulong Incr(ulong augend, ulong addend = 1)
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
        public static float Incr(float augend, float addend = 1)
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
        public static double Incr(double augend, double addend = 1)
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
        public static decimal Incr(decimal augend, decimal addend = 1)
        {
            return augend + addend;
        }

        #endregion

        #region Divide
        [Pure]
        public static sbyte Divide(sbyte dividend, sbyte divisor)
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
        public static byte Divide(byte dividend, byte divisor)
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
        public static short Divide(short dividend, short divisor)
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
        public static ushort Divide(ushort dividend, ushort divisor)
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
        public static int Divide(int dividend, int divisor)
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
        public static uint Divide(uint dividend, uint divisor)
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
        public static long Divide(long dividend, long divisor)
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
        public static ulong Divide(ulong dividend, ulong divisor)
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
        public static float Divide(float dividend, float divisor)
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
        public static double Divide(double dividend, double divisor)
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
        public static decimal Divide(decimal dividend, decimal divisor)
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
        public static sbyte Decr(sbyte minuend, sbyte subtrahend)
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
        public static byte Decr(byte minuend, byte subtrahend = 1)
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
        public static short Decr(short minuend, short subtrahend = 1)
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
        public static ushort Decr(ushort minuend, ushort subtrahend = 1)
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
        public static int Decr(int minuend, int subtrahend = 1)
        {
            return minuend - subtrahend;
        }

        [Pure]
        public static uint Decr(uint minuend, uint subtrahend = 1)
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
        public static long Decr(long minuend, long subtrahend = 1)
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
        public static ulong Decr(ulong minuend, ulong subtrahend = 1)
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
        public static float Decr(float minuend, float subtrahend = 1)
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
        public static double Decr(double minuend, double subtrahend = 1)
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
        public static decimal Decr(decimal minuend, decimal subtrahend)
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
        public static sbyte Multiply(sbyte multiplier, sbyte multiplicand)
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
        public static byte Multiply(byte multiplier, byte multiplicand)
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
        public static short Multiply(short multiplier, short multiplicand)
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
        public static ushort Multiply(ushort multiplier, ushort multiplicand)
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
        public static int Multiply(int multiplier, int multiplicand)
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
        public static uint Multiply(uint multiplier, uint multiplicand)
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
        public static long Multiply(long multiplier, long multiplicand)
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
        public static ulong Multiply(ulong multiplier, ulong multiplicand)
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
        public static float Multiply(float multiplier, float multiplicand)
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
        public static double Multiply(double multiplier, double multiplicand)
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
        public static decimal Multiply(decimal multiplier, decimal multiplicand)
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
        public static sbyte Remainder(sbyte dividend, sbyte divisor)
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
        public static byte Remainder(byte dividend, byte divisor)
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
        public static short Remainder(short dividend, short divisor)
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
        public static ushort Remainder(ushort dividend, ushort divisor)
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
        public static int Remainder(int dividend, int divisor)
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
        public static uint Remainder(uint dividend, uint divisor)
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
        public static long Remainder(long dividend, long divisor)
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
        public static ulong Remainder(ulong dividend, ulong divisor)
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
        public static float Remainder(float dividend, float divisor)
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
        public static double Remainder(double dividend, double divisor)
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
        public static decimal Remainder(decimal dividend, decimal divisor)
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
        public static sbyte ShiftLeft(sbyte value, int count)
        {
            return (sbyte)(value << count);
        }

        [Pure]
        public static byte ShiftLeft(byte value, int count)
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
        public static short ShiftLeft(short value, int count)
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
        public static ushort ShiftLeft(ushort value, int count)
        {
            return (ushort)(value << count);
        }

        [Pure]
        public static int ShiftLeft(int value, int count)
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
        public static uint ShiftLeft(uint value, int count)
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
        public static long ShiftLeft(long value, int count)
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
        public static ulong ShiftLeft(ulong value, int count)
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
        public static sbyte ShiftRight(sbyte value, int count)
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
        public static byte ShiftRight(byte value, int count)
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
        public static short ShiftRight(short value, int count)
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
        public static ushort ShiftRight(ushort value, int count)
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
        public static int ShiftRight(int value, int count)
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
        public static uint ShiftRight(uint value, int count)
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
        public static long ShiftRight(long value, int count)
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
        public static ulong ShiftRight(ulong value, int count)
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
    }
}

