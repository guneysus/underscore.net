﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fn.net
{
    public static class Fn
    {
        #region bind | compose functions up to 5 starting a generator func
        public static Func<TResult> bind<T1, TResult>(
    Func<T1> f1,
    Func<T1, TResult> fr) => () => fr(f1());

        public static Func<TResult> bind<T1, T2, TResult>(
            Func<T1> f1,
            Func<T1, T2> f2,
            Func<T2, TResult> fr) => () => fr(f2(f1()));

        public static Func<TResult> bind<T1, T2, T3, TResult>(
            Func<T1> f1,
            Func<T1, T2> f2,
            Func<T2, T3> f3,
            Func<T3, TResult> fr) => () => fr(f3(f2(f1())));

        public static Func<TResult> bind<T1, T2, T3, T4, TResult>(
            Func<T1> f1,
            Func<T1, T2> f2,
            Func<T2, T3> f3,
            Func<T3, T4> f4,
            Func<T4, TResult> fr) => () => fr(f4(f3(f2(f1()))));
        #endregion

        #region bind | compose functions up to 5

        public static Func<T1, TResult> bind<T1, T2, TResult>(
            Func<T1, T2> f1,
            Func<T2, TResult> fr) => t1 => fr(f1(t1));

        public static Func<T1, TResult> bind<T1, T2, T3, TResult>(
            Func<T1, T2> f1,
            Func<T2, T3> f2,
            Func<T3, TResult> fr) => t1 => fr(f2(f1(t1)));

        public static Func<T1, TResult> bind<T1, T2, T3, T4, TResult>(
            Func<T1, T2> f1,
            Func<T2, T3> f2,
            Func<T3, T4> f3,
            Func<T4, TResult> fr) => t1 => fr(f3(f2(f1(t1))));
        #endregion

        #region curry | decrease the degree of functions by 1

        public static Func<TR> curry<T1, TR>(Func<T1, TR> f, T1 t1) => () => f(t1);
        public static Func<T2, TR> curry<T1, T2, TR>(Func<T1, T2, TR> f, T1 t1) => (T2 t2) => f(t1, t2);
        public static Func<T2, T3, TR> curry<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, T1 t1) => (T2 t2, T3 t3) => f(t1, t2, t3);
        public static Func<T2, T3, T4, TR> curry<T1, T2, T3, T4, TR>(Func<T1, T2, T3, T4, TR> f, T1 t1) => (T2 t2, T3 t3, T4 t4) => f(t1, t2, t3, t4);

        #endregion

        #region curry | decrease the degree of functions by 2

        public static Func<TR> curry<T1, T2, TR>(Func<T1, T2, TR> f, T1 t1, T2 t2) => () => f(t1, t2);
        public static Func<T3, TR> curry<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, T1 t1, T2 t2) => (T3 t3) => f(t1, t2, t3);
        public static Func<T3, T4, TR> curry<T1, T2, T3, T4, TR>(Func<T1, T2, T3, T4, TR> f, T1 t1, T2 t2) => (T3 t3, T4 t4) => f(t1, t2, t3, t4);

        #endregion

        #region curry | decrease the degree of functions by 3

        public static Func<TR> curry<T0, T2, T3, TR>(Func<T0, T2, T3, TR> f, T0 t1, T2 t2, T3 t3) => () => f(t1, t2, t3);
        public static Func<T4, TR> curry<T1, T2, T3, T4, TR>(Func<T1, T2, T3, T4, TR> f, T1 t1, T2 t2, T3 t3) => (T4 t4) => f(t1, t2, t3, t4);

        #endregion

        #region curry | decrease the degree of functions by 4

        public static Func<TR> curry<T1, T2, T3, T4, TR>(Func<T1, T2, T3, T4, TR> f, T1 t1, T2 t2, T3 t3, T4 t4) => () => f(t1, t2, t3, t4);

        #endregion

        /// <summary>
        /// compose N functions that parameter and return type is same
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="functions"></param>
        /// <returns></returns>
        public static Func<T, T> pipe<T>(params Func<T, T>[] functions)
        {
            Func<Func<T, T>, Func<T, T>, Func<T, T>> f = (Func<T, T> fl, Func<T, T> fr) => t => fr(fl(t));
            return functions.Aggregate(f);
        }
    }
}
