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

    }
}
