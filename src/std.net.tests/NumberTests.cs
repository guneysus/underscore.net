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

    public class NumberTests
    {
        private readonly ITestOutputHelper output;

        public NumberTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        #region InRange

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_sbyte(sbyte number, sbyte end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_sbyte_end(sbyte number, sbyte start, sbyte end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_byte(byte number, byte end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_byte_end(byte number, byte start, byte end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_short(short number, short end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_short_end(short number, short start, short end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_ushort(ushort number, ushort end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_ushort_end(ushort number, ushort start, ushort end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_int(int number, int end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_int_end(int number, int start, int end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_uint(uint number, uint end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_uint_end(uint number, uint start, uint end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_long(long number, long end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_long_end(long number, long start, long end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_ulong(ulong number, ulong end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_ulong_end(ulong number, ulong start, ulong end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_float(float number, float end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_float_end(float number, float start, float end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_double(double number, double end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_double_end(double number, double start, double end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        [Theory]
        [InlineData(5, 20, true)]
        public void InRange_decimal(decimal number, decimal end, bool expected) => Assert.Equal(expected, inrange(number, end));

        [Theory]
        [InlineData(5, 3, 20, true)]
        public void InRange_decimal_end(decimal number, decimal start, decimal end, bool expected) => Assert.Equal(expected, inrange(number, start, end));

        #endregion

    }
}
