﻿using System;
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
        public static IEnumerable<T> intersect<T>(
            IEnumerable<T> first,
            IEnumerable<T> second)
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
        public static IEnumerable<T> intersect<T>(
            IEnumerable<T> first,
            IEnumerable<T> second,
            IEqualityComparer<T> comparer)
        {
            return first.Intersect(second, comparer);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<K> keys<K, V>(Dictionary<K, V> data)
        {
            return data.Keys;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<V> values<K, V>(Dictionary<K, V> data)
        {
            return data.Values;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> compact<T>(IEnumerable<Nullable<T>> items) where T : struct
        {
            return items
                .Where(x => x.HasValue)
                .Select(x => x.Value);
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


        [Pure]
        public static IEnumerable<T> sort<T>(
            IEnumerable<T> enumerable,
            IComparer<T> comparer)
        {
            List<T> sorted = enumerable.ToList();
            sorted.Sort(comparer);
            return sorted;
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
        public static IEnumerable<ValueTuple<T1, T2>> zip<T1, T2>(
            IEnumerable<T1> first,
            IEnumerable<T2> second)
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
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IQueryable<TResult> zip<TFirst, TSecond, TResult>(
            IQueryable<TFirst> first,
            IEnumerable<TSecond> second,
            Expression<Func<TFirst, TSecond, TResult>> resultSelector)
        {
            return first.Zip(second, resultSelector);
        }

        /// <summary>
        /// from: https://stackoverflow.com/a/12795900/1766716
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [Pure]
        public static bool same<T>(
            IEnumerable<T> first,
            IEnumerable<T> second)
        {
            List<T> firstNotSecond = first.Except(second).ToList();
            List<T> secondNotFirst = second.Except(first).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        [Pure]
        public static bool same<TKey, TValue>(
            IEnumerable<KeyValuePair<TKey, TValue>> first,
            IEnumerable<KeyValuePair<TKey, TValue>> second)
        {
            var firstNotSecond = first.Except(second).ToList();
            var secondNotFirst = second.Except(first).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        [Pure]
        public static bool same<TKey, TValue>(
            IEnumerable<KeyValuePair<TKey, TValue>> first,
            IEnumerable<KeyValuePair<TKey, TValue>> second,
            IEqualityComparer<KeyValuePair<TKey, TValue>> equalityComparer)
        {
            var firstNotSecond = first.Except(second, equalityComparer).ToList();
            var secondNotFirst = second.Except(first, equalityComparer).ToList();
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
        public static bool same<T>(
            IEnumerable<T> first,
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
        public static bool same<TKey, TValue>(
            Dictionary<TKey, TValue> first,
            Dictionary<TKey, TValue> second)
        {
            List<KeyValuePair<TKey, TValue>> firstNotSecond = first.Except(second).ToList();
            List<KeyValuePair<TKey, TValue>> secondNotFirst = second.Except(first).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        [Pure]
        public static IEnumerable<(DiffType, T)> diff<T>(
            IEnumerable<T> source,
            IEnumerable<T> target)
        {
            IEnumerable<T> added = target.Except(source);
            IEnumerable<T> deleted = source.Except(target);
            IEnumerable<T> same = source.Intersect(target);

            foreach (var item in added)
                yield return (DiffType.Added, item);

            foreach (var item in deleted)
                yield return (DiffType.Deleted, item);

            foreach (var item in same)
                yield return (DiffType.Same, item);
        }

        [Pure]
        public static IEnumerable<(DiffType, KeyValuePair<TKey, TValue>)> diff<TKey, TValue>(
            IDictionary<TKey, TValue> source,
            IDictionary<TKey, TValue> target)
        {
            var added = target.Keys.Except(source.Keys).Select(k => new KeyValuePair<TKey, TValue>(k, target[k]));
            var deleted = source.Keys.Except(target.Keys).Select(k => new KeyValuePair<TKey, TValue>(k, source[k]));

            var commonKeys = source.Keys.Intersect(target.Keys);

            var same = commonKeys.Where(k => source[k].Equals(target[k])).Select(k => new KeyValuePair<TKey, TValue>(k, source[k]));
            var updated = commonKeys.Where(k => !source[k].Equals(target[k])).Select(k => new KeyValuePair<TKey, TValue>(k, target[k]));

            foreach (var item in added)
                yield return (DiffType.Added, item);

            foreach (var item in deleted)
                yield return (DiffType.Deleted, item);

            foreach (var item in updated)
                yield return (DiffType.Updated, item);

            foreach (var item in same)
                yield return (DiffType.Same, item);
        }

        [Pure]
        public static DiffResult<T> diffA<T>(
            IEnumerable<T> source,
            IEnumerable<T> target)
        {
            IEnumerable<T> added = target.Except(source);
            IEnumerable<T> deleted = source.Except(target);
            IEnumerable<T> same = source.Intersect(target);
            return new DiffResult<T>(added, deleted, same);
        }

        [Pure]
        public static DiffResult<TKey, TValue> diffa<TKey, TValue>(
            IDictionary<TKey, TValue> source,
            IDictionary<TKey, TValue> target)
        {
            var added = target.Keys.Except(source.Keys).Select(k => new KeyValuePair<TKey, TValue>(k, target[k]));
            var deleted = source.Keys.Except(target.Keys).Select(k => new KeyValuePair<TKey, TValue>(k, source[k]));

            var sameKeys = source.Keys.Intersect(target.Keys);

            var same = sameKeys.Where(k => source[k].Equals(target[k])).Select(k => new KeyValuePair<TKey, TValue>(k, source[k]));
            var updated = sameKeys.Where(k => !source[k].Equals(target[k])).Select(k => new KeyValuePair<TKey, TValue>(k, target[k]));

            return new DiffResult<TKey, TValue>(added, deleted, updated, same);
        }


        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [Pure]
        public static Dictionary<K, V> merge<K, V>(
            Dictionary<K, V> first,
            Dictionary<K, V> second)
        {
            Dictionary<K, V> result = new Dictionary<K, V>();
            foreach (KeyValuePair<K, V> item in first)
                result.Add(item.Key, item.Value);

            foreach (KeyValuePair<K, V> item in second)
                result.Add(item.Key, item.Value);

            return second;
        }

        [Pure]
        public static IEnumerable<char> merge(params IEnumerable<char>[] args)
        {
            return args.Aggregate((a, b) => a.Union(b));
        }

        /// <summary>
        /// TODO #Doc REVIEW
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="data"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        [Pure]
        public static Dictionary<K, V> omitKeys<K, V>(
            Dictionary<K, V> data,
            params K[] keys)
        {
            IEnumerable<K> keyList = Iter.keys(data).Except(keys);
            Dictionary<K, V> result = new Dictionary<K, V>();

            foreach (K k in keyList)
            {
                result[k] = data[k];
            }

            return result;
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="data"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [Pure]
        public static Dictionary<K, V> omitBy<K, V>(
            Dictionary<K, V> data,
            Func<KeyValuePair<K, V>, bool> predicate)
        {
            return data.Where(x => !predicate(x)).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="data"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [Pure]
        public static Dictionary<K, V> pickBy<K, V>(
            Dictionary<K, V> data,
            Func<KeyValuePair<K, V>, bool> predicate)
        {
            return data.Where(x => predicate(x)).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        [Pure]
        public static Dictionary<K, V> pickKeys<K, V>(
            Dictionary<K, V> data,
            params K[] keys)
        {
            Dictionary<K, V> result = new Dictionary<K, V>();

            foreach (K k in keys)
            {
                result[k] = data[k];
            }

            return result;
        }

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<char> asciiall => merge(asciiletters, asciipunc, digits);

        /// <summary>
        /// TODO #doc
        /// </summary>
        [Pure]
        public static IEnumerable<char> asciiletters => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// TODO #doc
        /// </summary>
        [Pure]
        public static IEnumerable<char> asciipunc => "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{\\¦}~";

        /// <summary>
        /// TODO #doc
        /// </summary>
        [Pure]
        public static IEnumerable<char> asciilower => "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// TODO #doc
        /// </summary>
        [Pure]
        public static IEnumerable<char> asciiupper => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// TODO #doc
        /// </summary>
        [Pure]
        public static IEnumerable<char> turkishandenglish => "abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ";

        /// <summary>
        /// TODO #doc
        /// </summary>
        [Pure]
        public static IEnumerable<char> turkish => "abcçdefgğhıijklmnoöprsştuüvyzABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

        /// <summary>
        /// TODO #doc
        /// </summary>
        [Pure]
        public static IEnumerable<char> digits => "0123456789";

        /// <summary>
        /// Recursively visits a tree-like data structure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="leafs"></param>
        /// <param name="startDepth"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<Tuple<int, T, T>> climber<T>(
            T root,
            Func<T, IEnumerable<T>> leafs,
            int startDepth = 1,
            int maxDepth = 10)
        {
            return climber<T, Tuple<int, T, T>>(root: root, leafs: leafs, factory: (item) => item, startDepth: startDepth, maxDepth: maxDepth);
            return visit(root, default, leafs, startDepth, maxDepth);
        }

        /// <summary>
        /// Recursively visits a tree-like data structure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="parent"></param>
        /// <param name="func"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<TResult> climber<T, TResult>(
            T root,
            Func<T, IEnumerable<T>> leafs,
            Func<Tuple<int, T, T>, TResult> factory,
            int startDepth = 1,
            int maxDepth = 10)
        {
            foreach (var item in visit(current: root, parent: default, leafs: leafs, depth: startDepth = 1, maxDepth: maxDepth))
            {
                yield return factory(item);
            }
        }

        /// <summary>
        /// Recursive visitor pattern generator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="parent"></param>
        /// <param name="leafs"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<Tuple<int, T, T>> visit<T>(
            T current,
            T parent,
            Func<T, IEnumerable<T>> leafs,
            int depth,
            int maxDepth)
        {
            yield return Tuple.Create(depth, current, parent);

            if (depth >= maxDepth)
                yield break;

            depth++;
            IEnumerable<T> children = leafs(current);

            if (children == null)
                yield break;

            if (children.Any())
                foreach (var child in children)
                    foreach (var (childDepth, subchild, subchildparent) in visit(current: child, parent: current, leafs: leafs, depth: depth, maxDepth: maxDepth))
                        yield return Tuple.Create(childDepth, subchild, subchildparent);
            else
                depth--;

            yield break;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> drop<T>(
            List<T> collection,
            int size)
        {
            return collection.Skip(size);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [Pure]
        public static IQueryable<T> drop<T>(
            IQueryable<T> collection,
            int size)
        {
            return collection.Skip(size);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> dropWhile<T>(
            List<T> collection,
            Func<T, bool> predicate)
        {
            return collection.Where(x => !predicate(x));
        }

        [Pure]
        public static IQueryable<T> dropWhile<T>(
            IQueryable<T> collection,
            Func<T, bool> predicate)
        {
            return collection.Where(x => !predicate(x));
        }

        [Pure]
        public static IQueryable<TResult> distinct<TSource, TKey, TResult>(
            IQueryable<TSource> queryable,
            Func<TSource, TKey> keySelector,
            Func<IGrouping<TKey, TSource>, TResult> selector)
        {
            var result = queryable.GroupBy(x => keySelector(x)).Select(group => selector(group));

            return result;
        }

        [Pure]
        public static Iterator<T> iterator<T>(
            Func<int> counter,
            Func<int, T> generator)
        {
            return new Iterator<T>(counter, generator);
        }

        [Pure]
        public static Iterator<TKey, TValue> iterator<TKey, TValue>(
            Func<IEnumerable<TKey>> keys,
            Func<TKey, TValue> values
            )
        {
            return new Iterator<TKey, TValue>(keys, values);
        }

    }
}
