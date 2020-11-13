using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using _ = fn.net.Fn;
using math.net;
using std.net;

namespace fn.net.tests
{

    public class ComposeTests : FnTestBase
    {
        public ComposeTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Simple_Compose_tests()
        {
            var ahmed = _.compose(
                FirstName => "Ahmed Şeref",
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

            Assert.Equal("Ahmed Şeref", firstName);

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

        [Fact]
        public void Mapper_Tests()
        {
            var prices = Std.list(100.00m, 200.0m);

            var calculatePricesWithTaxes = _.mapper<decimal>(x => x * 1.18m);

            var realPrices = calculatePricesWithTaxes(prices);

            Assert.Equal(118.00m, realPrices.ElementAt(prices.IndexOf(100.00m)));
            Assert.Equal(236.00m, realPrices.ElementAt(prices.IndexOf(200.00m)));

        }

        [Fact]
        public void Filterer_Tests()
        {
            var students = Std.list(
                (Name: "Ahmed", Age: 31),
                (Name: "Mehmet", Age: 30),
                (Name: "Mert", Age: 20)
            );

            var youngFilter = _.filterer<(string, int)>(item => item.Item2 <= 20);
            var oldFilter = _.filterer<(string, int)>(item => item.Item2 > 20);

            var youngs = youngFilter(students);
            var olds = oldFilter(students);

            Assert.True(youngs.Count() == 1);
            Assert.True(olds.Count() == 2);

        }
    }
}
