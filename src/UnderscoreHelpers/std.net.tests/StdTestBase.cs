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
    public abstract class StdTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public StdTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class StdString : StdTestBase
    {
        public StdString(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void pad_tests()
        {
            const string expected = "  abc   ";
            string actual = pad("abc", 8);

            output.WriteLine(expected);
            output.WriteLine(actual);

            Assert.Equal(expected, actual);

            Assert.Equal("_-abc_-_", pad("abc", 8, "_-"));
            Assert.Equal("--abc---", pad("abc", 8, "-"));
            Assert.Equal("abc", pad("abc", 3));
        }

        [Fact]
        public void pad_right_tests()
        {
            Assert.Equal("abc   ", padright("abc", 6));
            Assert.Equal("abc_-_", padright("abc", 6, "_-"));
            Assert.Equal("abc", padright("abc", 3));
        }

        [Fact]
        public void pad_left_tests()
        {
            Assert.Equal("   abc", padleft("abc", 6));
            Assert.Equal("_-_abc", padleft("abc", 6, "_-"));
            Assert.Equal("abc", padleft("abc", 3));

            Assert.Throws<ArgumentOutOfRangeException>(() => padleft("30690168", 6, '0'));
            Assert.Equal("030690168", padleft("30690168", 9, '0'));
        }

        [Fact]
        public void trim_tests()
        {
            Assert.Equal("abc", trim("    abc "));
            Assert.Equal("abc", trim("-_-abc-_-", "_-"));
            Assert.Throws<ArgumentNullException>(() => trim(null));
        }

        [Fact]
        public void trim_end()
        {
            Assert.Equal("    abc", trimright("    abc "));
            Assert.Equal("-_-abc", trimright("-_-abc-_-", "_-"));
            Assert.Throws<ArgumentNullException>(() => trimright(null));
        }

        [Fact]
        public void trim_start()
        {
            Assert.Equal("abc ", trimleft("    abc "));
            Assert.Equal("abc-_-", trimleft("-_-abc-_-", "_-"));
            Assert.Throws<ArgumentNullException>(() => trimleft(null));
        }


        [Fact]
        public void truncate_tests()
        {
            Assert.Equal("hi-diddly-ho there, neighbori…", truncate("hi-diddly-ho there, neighborino", 30));
        }

        [Fact]
        public void matchor_tests()
        {
            var matcher = matchor(@"\w+"); // extracts words

            string[] expected = new string[] { "fred", "barney", "pebbles" };
            var actual = matcher("fred, barney, & pebbles");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void mask_tests()
        {
            const string creditCard = "1234123412341234";
            const string expected = "1234-XXXX-XXXX-1234";

            string actual = mask(creditCard, @"(\d{4})(\d{4})(\d{4})(\d{4})", "$1-XXXX-XXXX-$4");

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

        #region Bin

        [Fact]
        public void Bin_sbyte()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_byte()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_short()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_ushort()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_int()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_uint()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_long()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_ulong()
        {
            const string Expected = "1111111111111111111111111111111111111111111111111111111111111111";
            Assert.Equal(Expected, bin(-1L));
            Assert.Equal(Expected, bin(ulong.MaxValue));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_float()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_double()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_decimal()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        #endregion

        [Fact]
        public void lower_case_Tests()
        {
            const string Expected = "foo bar";

            Assert.Equal(Expected, LowerCase("Foo Bar"));
            Assert.Equal(Expected, LowerCase("fooBar"));
            Assert.Equal(Expected, LowerCase("FOO BAR"));
        }

    }

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
            Assert.True(IsBool("true"));
            Assert.True(IsBool("TRUE"));
            Assert.True(IsBool("false"));
            Assert.True(IsBool("FALSE"));

            Assert.False(IsBool("foo"));
            Assert.False(IsBool("0"));
            Assert.False(IsBool("1"));
        }

        [Fact]
        public void Is_nan()
        {
            Assert.True(IsNan("true"));
            Assert.False(IsNan("0"));
            Assert.False(IsNan("0.4"));
            Assert.False(IsNan("1.1243459968574737722343"));
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
            Assert.True(IsInteger("1"));
            Assert.True(IsInteger("10"));

            Assert.False(IsInteger(".0"));
            Assert.False(IsInteger("1.0"));
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

            Assert.Equal(expected, IsFloat(s, culture));
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

            Assert.Equal(expected, IsFloat(s, culture));

        }

        [Fact]
        public void Is_number()
        {
            Assert.False(IsNumber("true"));
            Assert.True(IsNumber("0"));
            Assert.True(IsNumber("0.4"));
            Assert.True(IsNumber("1.1243459968574737722343"));
        }

        [Fact]
        public void Is_decimal()
        {
            Assert.True(IsDecimal("1"));
            Assert.True(IsDecimal("1.2"));

            Assert.False(IsDecimal("1.0D"));
            Assert.False(IsDecimal("1.3D"));
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
        public void eq_bool(bool value, bool other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(-127, -127, true)]
        [InlineData(0, 127, false)]
        public void eq_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 255, false)]
        public void eq_byte(byte value, byte other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_short(short value, short other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_int(int value, int other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_uint(uint value, uint other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_long(long value, long other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_float(float value, float other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_double(double value, double other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(255, 255, true)]
        [InlineData(0, 1000, false)]
        public void eq_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, Eq(value, other));

        [Theory]
        [InlineData('0', '0', true)]
        [InlineData('a', 'a', true)]
        [InlineData('b', 'a', false)]
        public void eq_char(char value, char other, bool expected) => Assert.Equal(expected, Eq(value, other));
        #endregion

        #region Gt
        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_byte(byte value, byte other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_short(short value, short other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_int(int value, int other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_uint(uint value, uint other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_long(long value, long other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_float(float value, float other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_double(double value, double other, bool expected) => Assert.Equal(expected, Gt(value, other));

        [Theory]
        [InlineData(127, 0, true)]
        [InlineData(0, 127, false)]
        public void gt_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, Gt(value, other));

        #endregion

        #region Gte
        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_byte(byte value, byte other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_short(short value, short other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_int(int value, int other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_uint(uint value, uint other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_long(long value, long other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_float(float value, float other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_double(double value, double other, bool expected) => Assert.Equal(expected, Gte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(0, 127, false)]
        public void gte_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, Gte(value, other));
        #endregion

        #region Lt
        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_byte(byte value, byte other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_short(short value, short other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_int(int value, int other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_uint(uint value, uint other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_long(long value, long other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_float(float value, float other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_double(double value, double other, bool expected) => Assert.Equal(expected, Lt(value, other));

        [Theory]
        [InlineData(125, 127, true)]
        [InlineData(127, 125, false)]
        public void Lt_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, Lt(value, other));
        #endregion

        #region Lte
        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_sbyte(sbyte value, sbyte other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_byte(byte value, byte other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_short(short value, short other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_ushort(ushort value, ushort other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_int(int value, int other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_uint(uint value, uint other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_long(long value, long other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_ulong(ulong value, ulong other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_float(float value, float other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_double(double value, double other, bool expected) => Assert.Equal(expected, Lte(value, other));

        [Theory]
        [InlineData(127, 127, true)]
        [InlineData(127, 125, false)]
        public void Lte_decimal(decimal value, decimal other, bool expected) => Assert.Equal(expected, Lte(value, other));
        #endregion

        [Fact]
        public void not()
        {
            Assert.True(Not(false));
            Assert.False(Not(true));
        }

        #region XOr

        [Fact]
        public void XOr_sbyte()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_byte()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_short()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_ushort()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_int()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_uint()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_long()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_ulong()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_float()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_double()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_decimal()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        [Fact]
        public void XOr_bool()
        {
            Assert.Equal(5, XOr(1, 4));
            Assert.Equal(-3, XOr(1, -4));
        }

        #endregion

        #region LOr

        [Fact]
        public void LOr_sbyte()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_byte()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_short()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_ushort()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_int()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_uint()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_long()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_ulong()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_float()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_double()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_decimal()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        [Fact]
        public void LOr_bool()
        {
            Assert.Equal(5, LOr(1, 4));
            Assert.Equal(-3, LOr(1, -4));
        }

        #endregion

        #region ShiftLeft

        [Fact]
        public void ShiftLeft_sbyte()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        [Fact]
        public void ShiftLeft_byte()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        [Fact]
        public void ShiftLeft_short()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        [Fact]
        public void ShiftLeft_ushort()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        [Fact]
        public void ShiftLeft_int()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        [Fact]
        public void ShiftLeft_uint()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        [Fact]
        public void ShiftLeft_long()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        [Fact]
        public void ShiftLeft_ulong()
        {
            Assert.Equal(16, ShiftLeft(1, 4));
            Assert.Equal(268435456, ShiftLeft(1, -4));
        }

        #endregion

        #region ShiftRight

        [Fact]
        public void ShiftRight_sbyte()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        [Fact]
        public void ShiftRight_byte()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        [Fact]
        public void ShiftRight_short()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        [Fact]
        public void ShiftRight_ushort()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        [Fact]
        public void ShiftRight_int()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        [Fact]
        public void ShiftRight_uint()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        [Fact]
        public void ShiftRight_long()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        [Fact]
        public void ShiftRight_ulong()
        {
            Assert.Equal(1, ShiftRight(16, 4));
            Assert.Equal(1, ShiftRight(2, 1));
        }

        #endregion

        #region Add
        [Theory]
        [InlineData(1, 126, 127)]
        public void add_sbyte(sbyte value, sbyte other, sbyte expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_byte(byte value, byte other, byte expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_short(short value, short other, short expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_ushort(ushort value, ushort other, ushort expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_int(int value, int other, int expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_uint(uint value, uint other, uint expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_long(long value, long other, long expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_ulong(ulong value, ulong other, ulong expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_float(float value, float other, float expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_double(double value, double other, double expected) => Assert.Equal(expected, Incr(value, other));

        [Theory]
        [InlineData(1, 126, 127)]
        public void add_decimal(decimal value, decimal other, decimal expected) => Assert.Equal(expected, Incr(value, other));
        #endregion

        #region Divide

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_sbyte(sbyte value, sbyte other, sbyte expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_byte(byte value, byte other, byte expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_short(short value, short other, short expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_ushort(ushort value, ushort other, ushort expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_int(int value, int other, int expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_uint(uint value, uint other, uint expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_long(long value, long other, long expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_ulong(ulong value, ulong other, ulong expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_float(float value, float other, float expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_double(double value, double other, double expected) => Assert.Equal(expected, Divide(value, other));

        [Theory]
        [InlineData(20, 5, 4)]
        public void divide_decimal(decimal value, decimal other, decimal expected) => Assert.Equal(expected, Divide(value, other));

        #endregion

        #region _.Decr

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_sbyte(sbyte value, sbyte other, sbyte expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_byte(byte value, byte other, byte expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_short(short value, short other, short expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_ushort(ushort value, ushort other, ushort expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_int(int value, int other, int expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_uint(uint value, uint other, uint expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_long(long value, long other, long expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_ulong(ulong value, ulong other, ulong expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_float(float value, float other, float expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_double(double value, double other, double expected) => Assert.Equal(expected, Decr(value, other));

        [Theory]
        [InlineData(20, 5, 15)]
        public void Decr_decimal(decimal value, decimal other, decimal expected) => Assert.Equal(expected, Decr(value, other));

        #endregion

        #region Remainder

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_sbyte(sbyte number, sbyte end, sbyte expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_byte(byte number, byte end, byte expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_short(short number, short end, short expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_ushort(ushort number, ushort end, ushort expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_int(int number, int end, int expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_uint(uint number, uint end, uint expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_long(long number, long end, long expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_ulong(ulong number, ulong end, ulong expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_float(float number, float end, float expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_double(double number, double end, double expected) => Assert.Equal(expected, Remainder(number, end));

        [Theory]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(3, 3, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Remainder_decimal(decimal number, decimal end, decimal expected) => Assert.Equal(expected, Remainder(number, end));

        #endregion
        #region Multiply

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_sbyte(sbyte multiplier, sbyte multiplicand, sbyte expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_byte(byte multiplier, byte multiplicand, byte expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_short(short multiplier, short multiplicand, short expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_ushort(ushort multiplier, ushort multiplicand, ushort expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_int(int multiplier, int multiplicand, int expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_uint(uint multiplier, uint multiplicand, uint expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_long(long multiplier, long multiplicand, long expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_ulong(ulong multiplier, ulong multiplicand, ulong expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_float(float multiplier, float multiplicand, float expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_double(double multiplier, double multiplicand, double expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

        [Theory]
        [InlineData(20, 5, 100)]
        public void multiply_decimal(decimal multiplier, decimal multiplicand, decimal expected) => Assert.Equal(expected, Multiply(multiplier, multiplicand));

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

internal class ComplexClass
{
    public NestedClass Nested { get; set; }
}

internal class NestedClass
{
    public int Id { get; set; }
}


internal class Point
{
    public int X { get; protected set; }
    public int Y { get; protected set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}