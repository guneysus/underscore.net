using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static std.net.Std;
using static fn.net.Fn;
using static refl.net.Refl;
using static iter.net.Iter;

namespace std.net.tests
{

    public class LangTests
    {
        private readonly ITestOutputHelper output;

        public LangTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Is_bool()
        {
            Assert.True(isbool("true"));
            Assert.True(isbool("TRUE"));
            Assert.True(isbool("false"));
            Assert.True(isbool("FALSE"));

            Assert.False(isbool("foo"));
            Assert.False(isbool("0"));
            Assert.False(isbool("1"));
        }

        [Fact]
        public void Is_nan()
        {
            Assert.True(isnan("true"));
            Assert.False(isnan("0"));
            Assert.False(isnan("0.4"));
            Assert.False(isnan("1.1243459968574737722343"));
        }

        [Fact]
        public void Is_null()
        {
            Guid? nGuid = default(Guid?);
            int? nInt = default(int?);
            bool? nBool = default(bool?);
            decimal? nDec = default(decimal?);
            float? nFloat = default(float?);
            double? nDouble = default(double?);
            DateTime? nDt = default(DateTime?);
            string nStr = default(string);

            Assert.True(isnull(nGuid));
            Assert.True(isnull(nInt));
            Assert.True(isnull(nBool));
            Assert.True(isnull(nDec));
            Assert.True(isnull(nFloat));
            Assert.True(isnull(nDouble));
            Assert.True(isnull(nDt));
            Assert.True(isnull(nStr));

            nGuid = Guid.Empty;
            nInt = int.MaxValue;
            nBool = true;
            nDec = decimal.MaxValue;
            nFloat = float.MaxValue;
            nDouble = double.MaxValue;
            nDt = DateTime.MaxValue;
            nStr = string.Empty;

            Assert.False(isnull(nGuid));
            Assert.False(isnull(nInt));
            Assert.False(isnull(nBool));
            Assert.False(isnull(nDec));
            Assert.False(isnull(nFloat));
            Assert.False(isnull(nDouble));
            Assert.False(isnull(nDt));
            Assert.False(isnull(nStr));
        }

        [Fact]
        public void Is_integer()
        {
            Assert.True(isinteger("1"));
            Assert.True(isinteger("10"));

            Assert.False(isinteger(".0"));
            Assert.False(isinteger("1.0"));
        }

        [Theory]
        [InlineData("1.0", true)]
        [InlineData("1,0", true)]
        [InlineData(",0", false)]
        [InlineData(".0", true)]
        [InlineData("1", true)]
        [InlineData("", false)]
        [InlineData("NaN", true)]
        public void Is_float_tr(string s, bool expected)
        {
            CultureInfo culture = new CultureInfo("tr-TR", true);

            output.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.ToString()}");
            output.WriteLine($"Current UI Culture: {CultureInfo.CurrentUICulture.ToString()}");

            Assert.Equal(expected, isfloat(s, culture));
        }

        [Theory]

        [InlineData("1.0", true)]
        [InlineData("1,0", true)]
        [InlineData(".0", true)]
        [InlineData(",0", false)]
        [InlineData("1", true)]
        [InlineData("", false)]
        [InlineData("NaN", true)]
        public void Is_float_en(string s, bool expected)
        {
            CultureInfo culture = new CultureInfo("en-US", true);

            output.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.ToString()}");
            output.WriteLine($"Current UI Culture: {CultureInfo.CurrentUICulture.ToString()}");

            Assert.Equal(expected, isfloat(s, culture));

        }

        [Fact]
        public void Is_number()
        {
            Assert.False(isnumber("true"));
            Assert.True(isnumber("0"));
            Assert.True(isnumber("0.4"));
            Assert.True(isnumber("1.1243459968574737722343"));
        }

        [Fact]
        public void Is_decimal()
        {
            Assert.True(isdecimal("1"));
            Assert.True(isdecimal("1.2"));

            Assert.False(isdecimal("1.0D"));
            Assert.False(isdecimal("1.3D"));
        }

        [Fact]
        public void comparer()
        {
            IComparer<Point> comparer = comparator<Point>((a, b) => (a.X + a.Y) - (b.X + b.Y));

            Assert.Equal(0, comparer.Compare(new Point(0, 0), new Point(0, 0)));

            Assert.True(comparer.Compare(new Point(100, 0), new Point(0, 0)) > 0);
            Assert.True(comparer.Compare(new Point(0, 0), new Point(100, 0)) < 0);
        }

        #region Eq
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, true)]
        [InlineData(true, false, false)]
        public void eq_bool(bool value, bool other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(-127, -127, true)]
        [InlineData(0, 127, false)]
        public void eq_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 255, false)]
        public void eq_byte(byte value, byte other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_short(short value, short other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_int(int value, int other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_uint(uint value, uint other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_long(long value, long other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_float(float value, float other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_double(double value, double other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, eq(value, other));

        [Theory]
        [InlineData('0', '0', true)]
        [InlineData('a', 'a', true)]
        [InlineData('b', 'a', false)]
        public void eq_char(char value, char other, bool expected) => Assert.Equal(expected, eq(value, other));
        #endregion

        #region Gt
        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_byte(byte value, byte other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_short(short value, short other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_int(int value, int other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_uint(uint value, uint other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_long(long value, long other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_float(float value, float other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_double(double value, double other, bool expected) => Assert.Equal(expected, gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, gt(value, other));

        #endregion

        #region Gte
        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_byte(byte value, byte other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_short(short value, short other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_int(int value, int other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_uint(uint value, uint other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_long(long value, long other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_float(float value, float other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_double(double value, double other, bool expected) => Assert.Equal(expected, gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, gte(value, other));
        #endregion

        #region Lt
        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_byte(byte value, byte other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_short(short value, short other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_int(int value, int other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_uint(uint value, uint other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_long(long value, long other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_float(float value, float other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_double(double value, double other, bool expected) => Assert.Equal(expected, lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, lt(value, other));
        #endregion

        #region Lte
        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_byte(byte value, byte other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_short(short value, short other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_int(int value, int other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_uint(uint value, uint other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_long(long value, long other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_float(float value, float other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_double(double value, double other, bool expected) => Assert.Equal(expected, lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, lte(value, other));
        #endregion

        [Fact]
        public void not_tests()
        {
            Assert.True(not(false));
            Assert.False(not(true));
        }

        #region XOr

        [Fact]
        public void XOr_sbyte()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_byte()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_short()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_ushort()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_int()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_uint()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_long()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_ulong()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_float()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_double()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_decimal()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        [Fact]
        public void XOr_bool()
        {
            Assert.Equal(5, xor(1, 4));
            Assert.Equal(-3, xor(1, -4));
        }

        #endregion

        #region LOr

        [Fact]
        public void LOr_sbyte()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_byte()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_short()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_ushort()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_int()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_uint()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_long()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_ulong()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_float()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_double()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_decimal()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        [Fact]
        public void LOr_bool()
        {
            Assert.Equal(5, lor(1, 4));
            Assert.Equal(-3, lor(1, -4));
        }

        #endregion

        #region ShiftLeft

        [Fact]
        public void ShiftLeft_sbyte()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        [Fact]
        public void ShiftLeft_byte()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        [Fact]
        public void ShiftLeft_short()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        [Fact]
        public void ShiftLeft_ushort()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        [Fact]
        public void ShiftLeft_int()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        [Fact]
        public void ShiftLeft_uint()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        [Fact]
        public void ShiftLeft_long()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        [Fact]
        public void ShiftLeft_ulong()
        {
            Assert.Equal(16, sleft(1, 4));
            Assert.Equal(268435456, sleft(1, -4));
        }

        #endregion

        #region ShiftRight

        [Fact]
        public void ShiftRight_sbyte()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        [Fact]
        public void ShiftRight_byte()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        [Fact]
        public void ShiftRight_short()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        [Fact]
        public void ShiftRight_ushort()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        [Fact]
        public void ShiftRight_int()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        [Fact]
        public void ShiftRight_uint()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        [Fact]
        public void ShiftRight_long()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        [Fact]
        public void ShiftRight_ulong()
        {
            Assert.Equal(1, sright(16, 4));
            Assert.Equal(1, sright(2, 1));
        }

        #endregion

        #region Add
        [Theory]
        [InlineData(1, 126, 127)]
        public void add_sbyte(sbyte value, sbyte other, sbyte expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_byte(byte value, byte other, byte expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_short(short value, short other, short expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_ushort(ushort value, ushort other, ushort expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_int(int value, int other, int expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_uint(uint value, uint other, uint expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_long(long value, long other, long expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_ulong(ulong value, ulong other, ulong expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_float(float value, float other, float expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_double(double value, double other, double expected) => Assert.Equal(expected, incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_decimal(decimal value, decimal other, decimal expected) => Assert.Equal(expected, incr(value, other));
        #endregion

        #region Divide

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_sbyte(sbyte value, sbyte other, sbyte expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_byte(byte value, byte other, byte expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_short(short value, short other, short expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_ushort(ushort value, ushort other, ushort expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_int(int value, int other, int expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_uint(uint value, uint other, uint expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_long(long value, long other, long expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_ulong(ulong value, ulong other, ulong expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_float(float value, float other, float expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_double(double value, double other, double expected) => Assert.Equal(expected, divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_decimal(decimal value, decimal other, decimal expected) => Assert.Equal(expected, divide(value, other));

        #endregion

        #region _.Decr

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_sbyte(sbyte value, sbyte other, sbyte expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_byte(byte value, byte other, byte expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_short(short value, short other, short expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_ushort(ushort value, ushort other, ushort expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_int(int value, int other, int expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_uint(uint value, uint other, uint expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_long(long value, long other, long expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_ulong(ulong value, ulong other, ulong expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_float(float value, float other, float expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_double(double value, double other, double expected) => Assert.Equal(expected, decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_decimal(decimal value, decimal other, decimal expected) => Assert.Equal(expected, decr(value, other));

        #endregion

        #region Remainder

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_sbyte(sbyte number, sbyte end, sbyte expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_byte(byte number, byte end, byte expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_short(short number, short end, short expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_ushort(ushort number, ushort end, ushort expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_int(int number, int end, int expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_uint(uint number, uint end, uint expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_long(long number, long end, long expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_ulong(ulong number, ulong end, ulong expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_float(float number, float end, float expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_double(double number, double end, double expected) => Assert.Equal(expected, remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_decimal(decimal number, decimal end, decimal expected) => Assert.Equal(expected, remainder(number, end));

        #endregion
        #region Multiply

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_sbyte(sbyte multiplier, sbyte multiplicand, sbyte expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_byte(byte multiplier, byte multiplicand, byte expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_short(short multiplier, short multiplicand, short expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_ushort(ushort multiplier, ushort multiplicand, ushort expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_int(int multiplier, int multiplicand, int expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_uint(uint multiplier, uint multiplicand, uint expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_long(long multiplier, long multiplicand, long expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_ulong(ulong multiplier, ulong multiplicand, ulong expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_float(float multiplier, float multiplicand, float expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_double(double multiplier, double multiplicand, double expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_decimal(decimal multiplier, decimal multiplicand, decimal expected) => Assert.Equal(expected, multiply(multiplier, multiplicand));

        #endregion


        [Fact]
        public void times_tests()
        {
            Func<int> fn = delegate () { return 10; };
            Func<int> fn2 = () => 10;
            Func<int> fn3 = () => 10;

            int[] expected = new int[] { 10, 10, 10 };

            Assert.Equal(expected.AsEnumerable(), repeat(fn, 3));
            Assert.Equal(expected.AsEnumerable(), repeat(fn2, 3));
            Assert.Equal(expected.AsEnumerable(), repeat(fn3, 3));
        }

        private Guid GuidFactory() => Guid.NewGuid();



        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "10")]
        [InlineData(3, "11")]
        [InlineData(4, "100")]
        [InlineData(8, "1000")]
        [InlineData(-1, "11111111111111111111111111111111")]
        public void to_bin(int v, string expected)
        {
            string actual = bin(v);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void String_Length()
        {
            Assert.Equal(0, len(string.Empty));
            Assert.Throws<NullReferenceException>(() => len(null));
            Assert.Equal(3, len("foo"));
        }

        [Fact]
        public void List_Lenght()
        {
            Assert.Equal(0, len(list<string>()));
            Assert.Equal(3, len(list(1, 3, 5)));
        }

        [Fact]
        public void Set_Nested_Prop()
        {
            var complex = new ComplexClass();
            var nested = new NestedClass();
            Set(complex, "Nested", nested);
            Set(complex, "Nested.Id", 10);

            Assert.Throws<ArgumentException>(() => Set(complex, "Nested.Id", ""));

            Assert.NotNull(complex.Nested);
            Assert.Equal(nested, complex.Nested);
            Assert.Equal(10, complex.Nested.Id);
        }
    }
}
