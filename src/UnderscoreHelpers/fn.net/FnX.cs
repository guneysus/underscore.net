using System;
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

        public static Func<T1, T6> compose<T1, T2, T3, T4, T5, T6>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5) => v => f5(f4(f3(f2(f1(v)))));

        public static Func<T1, T7> compose<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6) => v => f6(f5(f4(f3(f2(f1(v))))));

        public static Func<T1, T8> compose<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7) => v => f7(f6(f5(f4(f3(f2(f1(v)))))));

        public static Func<T1, T9> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8) => v => f8(f7(f6(f5(f4(f3(f2(f1(v))))))));

        public static Func<T1, T10> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9) => v => f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))));

        public static Func<T1, T11> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10) => v => f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))));

        public static Func<T1, T12> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11) => v => f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))));

        public static Func<T1, T13> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12) => v => f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))));

        public static Func<T1, T14> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13) => v => f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))));

        public static Func<T1, T15> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14) => v => f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))));

        public static Func<T1, T16> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15) => v => f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))));

        public static Func<T1, T17> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16) => v => f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))));

        public static Func<T1, T18> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17) => v => f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))));

        public static Func<T1, T19> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18) => v => f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))));

        public static Func<T1, T20> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19) => v => f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))));

        public static Func<T1, T21> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20) => v => f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))));

        public static Func<T1, T22> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21) => v => f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))));

        public static Func<T1, T23> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22) => v => f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))));

        public static Func<T1, T24> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22, Func<T23, T24> f23) => v => f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))));

        public static Func<T1, T25> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22, Func<T23, T24> f23, Func<T24, T25> f24) => v => f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))))));

        public static Func<T1, T26> compose<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, T4> f3, Func<T4, T5> f4, Func<T5, T6> f5, Func<T6, T7> f6, Func<T7, T8> f7, Func<T8, T9> f8, Func<T9, T10> f9, Func<T10, T11> f10, Func<T11, T12> f11, Func<T12, T13> f12, Func<T13, T14> f13, Func<T14, T15> f14, Func<T15, T16> f15, Func<T16, T17> f16, Func<T17, T18> f17, Func<T18, T19> f18, Func<T19, T20> f19, Func<T20, T21> f20, Func<T21, T22> f21, Func<T22, T23> f22, Func<T23, T24> f23, Func<T24, T25> f24, Func<T25, T26> f25) => v => f25(f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))))));

        #endregion

        #region pipe | semi auto generated :P
        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f) => f;

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2) => v => f2(f1(v));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3) => v => f3(f2(f1(v)));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4) => v => f4(f3(f2(f1(v))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5) => v => f5(f4(f3(f2(f1(v)))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6) => v => f6(f5(f4(f3(f2(f1(v))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7) => v => f7(f6(f5(f4(f3(f2(f1(v)))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8) => v => f8(f7(f6(f5(f4(f3(f2(f1(v))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9) => v => f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10) => v => f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11) => v => f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12) => v => f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13) => v => f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14) => v => f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15) => v => f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16) => v => f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17) => v => f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18) => v => f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18, Func<TResult, TResult> f19) => v => f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18, Func<TResult, TResult> f19, Func<TResult, TResult> f20) => v => f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18, Func<TResult, TResult> f19, Func<TResult, TResult> f20, Func<TResult, TResult> f21) => v => f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18, Func<TResult, TResult> f19, Func<TResult, TResult> f20, Func<TResult, TResult> f21, Func<TResult, TResult> f22) => v => f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18, Func<TResult, TResult> f19, Func<TResult, TResult> f20, Func<TResult, TResult> f21, Func<TResult, TResult> f22, Func<TResult, TResult> f23) => v => f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18, Func<TResult, TResult> f19, Func<TResult, TResult> f20, Func<TResult, TResult> f21, Func<TResult, TResult> f22, Func<TResult, TResult> f23, Func<TResult, TResult> f24) => v => f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))))));

        public static Func<TResult, TResult> pipe<TResult>(Func<TResult, TResult> f1, Func<TResult, TResult> f2, Func<TResult, TResult> f3, Func<TResult, TResult> f4, Func<TResult, TResult> f5, Func<TResult, TResult> f6, Func<TResult, TResult> f7, Func<TResult, TResult> f8, Func<TResult, TResult> f9, Func<TResult, TResult> f10, Func<TResult, TResult> f11, Func<TResult, TResult> f12, Func<TResult, TResult> f13, Func<TResult, TResult> f14, Func<TResult, TResult> f15, Func<TResult, TResult> f16, Func<TResult, TResult> f17, Func<TResult, TResult> f18, Func<TResult, TResult> f19, Func<TResult, TResult> f20, Func<TResult, TResult> f21, Func<TResult, TResult> f22, Func<TResult, TResult> f23, Func<TResult, TResult> f24, Func<TResult, TResult> f25) => v => f25(f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))))));
        #endregion

        #region bind

        
        public static Func<T2, TResult> bind<T1, T2, TResult>(Func<T1> ft1, Func<T1, T2, TResult> ft1t2tr) => (T2 t2) => ft1t2tr(ft1(), t2);
        public static Func<T2, T3, TResult> bind<T1, T2, T3, TResult>(Func<T1> ft1, Func<T1, T2, T3, TResult> ft1t2t3tr) => (T2 t2, T3 t3) => ft1t2t3tr(ft1(), t2, t3);
        public static Func<T2, T3, T4, TResult> bind<T1, T2, T3, T4, TResult>(Func<T1> ft1, Func<T1, T2, T3, T4, TResult> ft1t2t3t4tr) => (T2 t2, T3 t3, T4 t4) => ft1t2t3t4tr(ft1(), t2, t3, t4);
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
