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
    }
}
