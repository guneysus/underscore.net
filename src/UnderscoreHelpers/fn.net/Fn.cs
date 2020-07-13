using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace fn.net
{
    public static class Fn
    {
        #region AUTO GENERATED

        public static Func<T1, T2> compose<T1, T2>(Func<T1, T2> f1) => v => f1(v);

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

        #region semi auto generated :P
        public static Func<T, T> pipe<T>(Func<T, T> f1) => v => f1(v);

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2) => v => f2(f1(v));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3) => v => f3(f2(f1(v)));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4) => v => f4(f3(f2(f1(v))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5) => v => f5(f4(f3(f2(f1(v)))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6) => v => f6(f5(f4(f3(f2(f1(v))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7) => v => f7(f6(f5(f4(f3(f2(f1(v)))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8) => v => f8(f7(f6(f5(f4(f3(f2(f1(v))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9) => v => f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10) => v => f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11) => v => f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12) => v => f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13) => v => f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14) => v => f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15) => v => f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16) => v => f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17) => v => f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18) => v => f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18, Func<T, T> f19) => v => f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18, Func<T, T> f19, Func<T, T> f20) => v => f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18, Func<T, T> f19, Func<T, T> f20, Func<T, T> f21) => v => f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18, Func<T, T> f19, Func<T, T> f20, Func<T, T> f21, Func<T, T> f22) => v => f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18, Func<T, T> f19, Func<T, T> f20, Func<T, T> f21, Func<T, T> f22, Func<T, T> f23) => v => f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18, Func<T, T> f19, Func<T, T> f20, Func<T, T> f21, Func<T, T> f22, Func<T, T> f23, Func<T, T> f24) => v => f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v))))))))))))))))))))))));

        public static Func<T, T> pipe<T>(Func<T, T> f1, Func<T, T> f2, Func<T, T> f3, Func<T, T> f4, Func<T, T> f5, Func<T, T> f6, Func<T, T> f7, Func<T, T> f8, Func<T, T> f9, Func<T, T> f10, Func<T, T> f11, Func<T, T> f12, Func<T, T> f13, Func<T, T> f14, Func<T, T> f15, Func<T, T> f16, Func<T, T> f17, Func<T, T> f18, Func<T, T> f19, Func<T, T> f20, Func<T, T> f21, Func<T, T> f22, Func<T, T> f23, Func<T, T> f24, Func<T, T> f25) => v => f25(f24(f23(f22(f21(f20(f19(f18(f17(f16(f15(f14(f13(f12(f11(f10(f9(f8(f7(f6(f5(f4(f3(f2(f1(v)))))))))))))))))))))))));
        #endregion

        /// <summary>
        /// TODO #Test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seed"></param>
        /// <param name="fns"></param>
        /// <returns></returns>
        public static Func<T, T> aggregate<T>(Func<T> seed, params Func<T, T>[] fns) => _ => fns.Aggregate(seed(), (t, f) => f(t));

        public static Func<T1, R> fun<T1, R>(Func<T1, R> f) => f;

        /// <summary>
        /// /// TODO #Doc #FN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> map<T>(IEnumerable<T> source, Func<T, T> fn)
        {
            foreach (T item in source)
            {
                yield return fn(item);
            }
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
        public static IEnumerable<(int index, T value)> iter<T>(IEnumerable<T> source)
        {
            int i = 0;
            foreach (T item in source)
            {
                yield return (i, item);
                i++;
            }
        }

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
        /// <param name="n"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<T> times<T>(int n, Func<T> function)
        {
            for (int i = 0; i < n; i++)
            {
                yield return function();
            }
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
    }
}
