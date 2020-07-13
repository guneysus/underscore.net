using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iter.net
{
    /// <summary>
    /// TODO
    /// </summary>
    public static class Iter
    {

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> intersect<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            return first.Intersect(second);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> intersect<T>(IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            return first.Intersect(second, comparer);
        }

        /// <summary>
        /// TODO #doc
        /// TODO move to functional.net
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [Pure]
        public static IEqualityComparer<T> comparator<T>(Func<T, T, bool> comparer)
        {
            return new GenericEqualityComparer<T>(comparer);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="compare"></param>
        /// <returns></returns>
        [Pure]
        public static IComparer<T> comparator<T>(Func<T, T, int> compare)
        {
            return new GenericComparer<T>(compare);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> flatten<T>(IEnumerable<List<T>> enumerable)
        {
            return enumerable.Select(x => x).SelectMany(c => c);
        }

        #region Functional Tools
        [Pure]
        public static Converter<Tin, Tout> convertor<Tin, Tout>(Func<Tin, Tout> fn)
        {
            return (Tin s) => fn(s);
        }

        #endregion

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<ValueTuple<T1, T2>> zip<T1, T2>(IEnumerable<T1> first, IEnumerable<T2> second)
        {
            if (first.Count() != second.Count())
            {
                throw new ArgumentOutOfRangeException(nameof(first));
            }

            for (int i = 0; i < first.Count(); i++)
            {
                yield return (first.ElementAt(i), second.ElementAt(i));
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IQueryable<TResult> zip<TFirst, TSecond, TResult>(IQueryable<TFirst> source1, IEnumerable<TSecond> source2, Expression<Func<TFirst, TSecond, TResult>> resultSelector)
        {
            return source1.Zip(source2, resultSelector);
        }

        /// <summary>
        /// from: https://stackoverflow.com/a/12795900/1766716
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [Pure]
        public static bool same<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            List<T> firstNotSecond = first.Except(second).ToList();
            List<T> secondNotFirst = second.Except(first).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="equalityComparer"></param>
        /// <returns></returns>
        [Pure]
        public static bool same<T>(IEnumerable<T> first,
            IEnumerable<T> second,
            IEqualityComparer<T> equalityComparer)
        {
            List<T> firstNotSecond = first.Except(second, equalityComparer).ToList();
            List<T> secondNotFirst = second.Except(first, equalityComparer).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [Pure]
        public static bool same<TKey, TValue>(Dictionary<TKey, TValue> first, Dictionary<TKey, TValue> second)
        {
            List<KeyValuePair<TKey, TValue>> firstNotSecond = first.Except(second).ToList();
            List<KeyValuePair<TKey, TValue>> secondNotFirst = second.Except(first).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}
