using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using _ = fn.net.Fn;
using math.net;

namespace fn.net.tests
{
    public abstract class FnTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        protected FnTestBase()
        {

        }
        public FnTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class BindTests : FnTestBase
    {
        public BindTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Simple_Bind()
        {
            string num = " 1000.0  ";
            var trim = new Func<string, string>(s => s.Trim());
            Func<string, Decimal> toDecimal = decimal.Parse;

            Func<string, decimal> composed = _.bind(trim, toDecimal);
            var actual = composed(num);
            var expected = 1000.0m;

            Assert.Equal(expected, actual);
        }
    }

    public class ComposeTests : FnTestBase
    {
        public ComposeTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Simple_Compose_tests()
        {
            var ahmed = _.compose(
                FirstName => "Ahmed Þeref",
                LastName => "Güneysu",
                BirthDate => new DateTime(1989, 8, 21)
            );

            var mehmet = _.compose(
                FirstName => "Mehmet",
                LastName => "YILMAZ",
                Age => 30);

            var firstName = ahmed.Get<string>(FirstName => default);
            var birthDate = ahmed.Get<DateTime>(BirthDate => default);
            var ageOfMehmet = mehmet.Get<int>(Age => default);

            Assert.Equal("Ahmed Þeref", firstName);

            Assert.Throws<System.InvalidCastException>(() =>
            {
                var err = mehmet.Get<long>(Age => default);
            });

            Assert.Equal(30, ageOfMehmet);
            Assert.Equal(default, ahmed.Get<int>(Age => default));
        }

        [Fact]
        public void Swap()
        {
            Func<decimal, int, decimal> rounder = decimal.Round;
            Func<int, decimal, decimal> swappedRounder = _.swap<decimal, int, decimal>(decimal.Round);

            Func<decimal, decimal> oneDecimalRounder = _.curry(swappedRounder, 1);
            Func<decimal, decimal> twoDecimalRounder = _.curry(swappedRounder, 2);

            var result1 = oneDecimalRounder(100.244m);
            var result2 = twoDecimalRounder(100.244m);

            Assert.Equal(100.2m, result1);
            Assert.Equal(100.24m, result2);
        }

        [Fact]
        public void Memoizer_Tests()
        {
            var factorial = _.memoizer<int>(MathNet.factorial);

            var fiveFactorial1 = factorial(5);
            var fiveFactorial2 = factorial(5);
        }

    }
}
