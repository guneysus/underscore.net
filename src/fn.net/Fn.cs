using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        #region bind | compose function up to 26

        public static Func<T1, T6> bind<T1, T2, T3, T4, T5, T6>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5) => v => f5(f4(f3(f2(f1(v)))));

        public static Func<T1, T7> bind<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6) => v => f6(f5(f4(f3(f2(f1(v))))));

        public static Func<T1, T8> bind<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7) => v => f7(f6(f5(f4(f3(f2(f1(v)))))));

        public static Func<T1, T9> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8) => v => f8(f7(f6(f5(f4(f3(f2(f1(v))))))));

        public static Func<T1, T10> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9) => v => f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))));

        public static Func<T1, T11> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10) => v => f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))));

        public static Func<T1, T12> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11) => v => f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))));

        public static Func<T1, T13> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12) => v => f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))));

        public static Func<T1, T14> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13) => v => f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))));

        public static Func<T1, T15> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14) => v => f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))));

        public static Func<T1, T16> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15) => v => f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))));

        public static Func<T1, T17> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16) => v => f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))));

        public static Func<T1, T18> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17) => v => f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))));

        public static Func<T1, T19> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18) => v => f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))));

        public static Func<T1, T20> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19) => v => f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))));

        public static Func<T1, T21> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20) => v => f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))));

        public static Func<T1, T22> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21) => v => f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))));

        public static Func<T1, T23> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22) => v => f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))));

        public static Func<T1, T24> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22, Func<T23, T24> f23) => v => f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))));

        public static Func<T1, T25> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22, Func<T23, T24> f23, Func<T24, T25> f24) => v => f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))))));

        public static Func<T1, T26> bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22, Func<T23, T24> f23, Func<T24, T25> f24, Func<T25, T26> f25) => v => f25(f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))))));
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

        /// <summary>
        /// TODO #Test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seed"></param>
        /// <param name="fns"></param>
        /// <returns></returns>
        public static Func<T, T> aggregate<T>(Func<T> seed, params Func<T, T>[] fns) => _ => fns.Aggregate(seed(), (t, f) => f(t));

        public static Func<T, T> aggregate<T>(params Func<T, T>[] fns)
        {
            Func<Func<T, T>, Func<T, T>, Func<T, T>> accumulator = (fl, fr) => input => fr(fl(input));
            return fns.Aggregate(accumulator);
        }

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


        [Pure]
        public static Func<T, T> apply<T>(Func<T, T> func, int times)
        {
            return aggregate(Enumerable.Range(1, times).Select(x => func).ToArray());
        }

        /// <summary>
        /// /// TODO #test #Doc #FN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<TResult> map<T, TResult>(IEnumerable<T> source, Func<T, TResult> fn)
        {
            //return source.Select(fn);
            foreach (T item in source)
                yield return fn(item);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [Pure]
        public static T reduce<T>(IEnumerable<T> source, Func<T, T, T> func) => source.Aggregate(func);

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
        public static R reduce<T, R>(IEnumerable<T> source, R seed, Func<R, T, R> func) => source.Aggregate(seed, func);

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
        public static TResult reduce<TSource, TAccumulate, TResult>(IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) => source.Aggregate(seed, func, resultSelector);

        /// <summary>
        /// TODO #test #Doc #FN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fn"></param>
        public static IEnumerable<(T value, int index)> iter<T>(IEnumerable<T> source) => source.Select((item, index) => (item, index));


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
        public static IEnumerable<IEnumerable<T>> chunks<T>(IEnumerable<T> collection, int size)
        {
            List<List<T>> chunks = new List<List<T>>();
            int chunkCount = collection.Count() / size;

            if (collection.Count() % size > 0)
            {
                ++chunkCount;
            }

            for (int i = 0; i < chunkCount; i++)
            {
                chunks.Add(collection.Skip(i * size).Take(size).ToList());
            }

            return chunks;
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
        public static IEnumerable<IEnumerable<T>> chunks<T>(int size, IEnumerable<T> collection) => chunks(size, collection);

        #region Instance
        /// <summary>
        /// Returns the default constructor as delegate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static Func<T> ctor<T>() where T : new()
        {
            return () => new T();
        }

        /// <summary>
        /// Returns the constructor with single argument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [Pure]
        public static Func<T1, T> ctor<T1, T>()
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(T1) });

            return t1 => ctor != null ? (T)ctor.Invoke(new object[] { t1 }) : default;
        }

        /// <summary>
        /// Returns the constructor with two arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static Func<T1, T2, T> ctor<T1, T2, T>()
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(T1), typeof(T2) });

            return (t1, t2) => ctor != null ? (T)ctor.Invoke(new object[] { t1, t2 }) : default;
        }

        /// <summary>
        /// Returns the constructor with three arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static Func<T1, T2, T3, T> ctor<T1, T2, T3, T>()
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3) });

            return (t1, t2, t3) => ctor != null ? (T)ctor.Invoke(new object[] { t1, t2, t3 }) : default;
        }
        #endregion

        #region Compose Object
        /// <summary>
        /// Compose object like tuples
        /// </summary>
        /// <param name="exps"></param>
        /// <returns></returns>
        public static Compose<object> compose(params Expression<Func<string, object>>[] exps) => new Compose<object>(exps);

        #endregion

        /// <summary>
        /// swap parameter orders and returns new function
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Func<T2, T1, R> swap<T1, T2, R>(Func<T1, T2, R> f) => (t2, t1) => f(t1, t2);

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static Action combine(params Action[] actions)
        {
            return (Action)Delegate.Combine(actions.ToArray());
        }

        /// <summary>
        /// TODO #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static Action combine<T>(params Func<T>[] actions)
        {
            return () => { _ = (Func<T>)Delegate.Combine(actions.ToArray()); };
        }

        /// <summary>
        /// https://www.infoq.com/news/2007/01/CSharp-memory/
        /// TODO #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<T, TResult> memoizer<T, TResult>(Func<T, TResult> func)
        {
            var map = new Dictionary<T, TResult>();

            return a =>
            {
                TResult value;
                if (map.TryGetValue(a, out value))
                {
                    return value;
                }

                value = func(a);
                map.Add(a, value);
                return value;
            };
        }

        /// <summary>
        /// https://www.infoq.com/news/2007/01/CSharp-memory/
        /// TODO #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<T, T> memoizer<T>(Func<T, T> func)
        {
            var map = new Dictionary<T, T>();

            return a =>
            {
                T value;
                if (map.TryGetValue(a, out value))
                {
                    return value;
                }

                value = func(a);
                map.Add(a, value);
                return value;
            };
        }

        /// <summary>
        /// https://www.infoq.com/news/2007/01/CSharp-memory/
        /// TODO #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<(T1, T2), TResult> memoizer<T1, T2, TResult>(Func<(T1, T2), TResult> func)
        {
            var map = new Dictionary<(T1, T2), TResult>();

            return a =>
            {
                TResult value;
                if (map.TryGetValue(a, out value))
                {
                    return value;
                }

                value = func(a);
                map.Add(a, value);
                return value;
            };
        }


        /// <summary>
        /// TODO #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<IEnumerable<T>, IEnumerable<TResult>> mapper<T, TResult>(Func<T, TResult> func) => source => source.Select(func);


        /// <summary>
        /// Todo #test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<IEnumerable<T>, IEnumerable<T>> mapper<T>(Func<T, T> func) => source => source.Select(func);

    }
}
