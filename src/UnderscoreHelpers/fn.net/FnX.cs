﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace fn.net
{
    public static class FnX
    {
        #region compose | AUTO GENERATED

        public static Func<T2> compose<T1, T2>(Func<T1> f1, Func<T1, T2> f2) => () => f2(f1());

        public static Func<T1, T3> compose<T1, T2, T3>(Func<T1, T2> f1, Func<T2, T3> f2) => v => f2(f1(v));

        public static Func<T1, T4> compose<T1, T2, T3, T4>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3) => v => f3(f2(f1(v)));

        public static Func<T1, T5> compose<T1, T2, T3, T4, T5>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4) => v => f4(f3(f2(f1(v))));


        #endregion

        #region pipe | semi auto generated :P
        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f) => f;

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2) => v => f2(f1(v));


        #endregion


        #region IEnumerable functions
        /// <summary>
        /// TODO #Test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seed"></param>
        /// <param name="fns"></param>
        /// <returns></returns>
        public static Func<T, T> aggregate<T>(Func<T> seed, params Func<T, T>[] fns) => _ => fns.Aggregate(seed(), (t, f) => f(t));


        /// <summary>
        /// /// TODO #Doc #FN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> apply<T>(IEnumerable<T> source, Func<T, T> fn)
        {
            foreach (T item in source)
                yield return fn(item);
        }

        /// <summary>
        /// /// TODO #Doc #FN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<TResult> apply<T, TResult>(IEnumerable<T> source, Func<T, TResult> fn)
        {
            //return source.Select(fn);
            foreach (T item in source)
                yield return fn(item);
        }

        /// <summary>
        /// TODO #Doc #FN SAME AS ITER
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void apply<T>(IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// TODO #Doc #FN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fn"></param>
        public static IEnumerable<(T value, int index)> iter<T>(IEnumerable<T> source) => source.Select((item, index) => (item, index));

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [Pure]
        public static T reduce<T>(IEnumerable<T> source, Func<T, T, T> func)
        {
            return source.Aggregate(func);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="source"></param>
        /// <param name="seed"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [Pure]
        public static R reduce<T, R>(IEnumerable<T> source, R seed, Func<R, T, R> func)
        {
            return source.Aggregate(seed, func);
        }

        /// <summary>
        /// TODO #test #doc
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TAccumulate"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="seed"></param>
        /// <param name="func"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        [Pure]
        public static TResult reduce<TSource, TAccumulate, TResult>(IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            return source.Aggregate(seed, func, resultSelector);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> repeat<T>(Func<T> function, int count)
        {
            for (int i = 0; i < count; i++)
                yield return function();
        }

        /// <summary>
        /// https://codereview.stackexchange.com/a/90198/32074
        /// TODO with yield return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<IEnumerable<T>> chunk<T>(IEnumerable<T> collection, int size)
        {
            List<List<T>> chunks = new List<List<T>>();
            int chunkCount = collection.Count() / size;

            if (collection.Count() % size > 0)
            {
                chunkCount++;
            }

            for (int i = 0; i < chunkCount; i++)
            {
                chunks.Add(collection.Skip(i * size).Take(size).ToList());
            }

            return chunks;
        }
        #endregion

        #region Curry

        public static Func<T2> curry<T1, T2>(Func<T1, T2> act, T1 t1) => () => act(t1);

        public static Action curry<T1>(Action<T1> act, T1 t1) => () => act(t1);

        public static Action<T2> curry<T1, T2>(Action<T1, T2> act, T1 t1) => t2 => act(t1, t2); 
        #endregion

        #region Instance
        /// <summary>
        /// Returns the default constructor as delegate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static Func<T> instance<T>()
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { });

            return new Func<T>(() =>
            {

                return ctor != null ? (T)ctor.Invoke(new object[] { }) : default;
            });
        }

        /// <summary>
        /// Returns the constructor with single argument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [Pure]
        public static Func<T1, T> instance<T, T1>()
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(T1) });

            return new Func<T1, T>(t1 =>
            {
                return ctor != null ? (T)ctor.Invoke(new object[] { t1 }) : default;
            });
        }

        /// <summary>
        /// Returns the constructor with two arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static Func<T1, T2, T> instance<T, T1, T2>()
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(T1), typeof(T2) });

            return new Func<T1, T2, T>((t1, t2) =>
            {
                return ctor != null ? (T)ctor.Invoke(new object[] { t1, t2 }) : default;
            });
        }

        /// <summary>
        /// Returns the constructor with three arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static Func<T1, T2, T3, T> instance<T, T1, T2, T3>()
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3) });

            return new Func<T1, T2, T3, T>((t1, t2, t3) =>
            {
                return ctor != null ? (T)ctor.Invoke(new object[] { t1, t2, t3 }) : default;
            });
        } 
        #endregion

    }
}