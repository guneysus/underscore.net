using System;
using Xunit;
using Xunit.Abstractions;
using _ = math.net.MathNet;

namespace math.net.tests
{

    public class SimpleMathTests : MathNetTestBase
    {
        public SimpleMathTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(0.0175d, 6, 1799.00, -318.46d)]
        public void pmt_tests(double rate, int term, decimal amount, decimal expected)
        {
            Assert.Equal(expected, _.round(_.PMT(rate, term, amount), 2));
        }


        [Theory]
        [InlineData(4.006, 4.0)]
        [InlineData(0.046, 0)]
        public void floor_tests(decimal number, decimal expected)
        {
            Assert.Equal(expected, _.floor(number));
        }


        [Fact]
        public void Factorial_Tests()
        {
            Assert.Equal(6, _.factorial(3));
        }


    }
}
