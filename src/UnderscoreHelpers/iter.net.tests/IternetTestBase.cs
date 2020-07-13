using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using static iter.net.Iter;

namespace iter.net.tests
{
    public abstract class IternetTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public IternetTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class CollectionHelpersTests : IternetTestBase
    {
        public CollectionHelpersTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Intersect_tests()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 };
            int[] oddNumbers = new int[] { 1, 3, 5, 7, 9 };

            Assert.Equal(new int[] { 1, 3, 5, 7, 9 }, intersect(numbers, oddNumbers));
        }

        [Fact]
        public void Intersect_with_lambda_equality_comparer()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 };
            int[] oddNumbers = new int[] { 1, 3, 5, 7, 9 };

            int[] expected = new int[] { 1, 3 };
            var comparer = comparator((int a, int b) => a == b && b < 5);

            IEnumerable<int> intersectedNumbersSmallerThanFive = intersect(numbers, oddNumbers, comparer);

            Assert.Equal(expected, intersectedNumbersSmallerThanFive);
        }

        [Fact]
        public void equality_comparer()
        {
            IEqualityComparer<Point> comparer = comparator<Point>((a, b) => a.X == b.X && a.Y == b.Y);

            Assert.True(comparer.Equals(new Point(0, 0), new Point(0, 0)));

            Assert.False(comparer.Equals(new Point(1, 0), new Point(0, 0)));
            Assert.False(comparer.Equals(new Point(0, 1), new Point(0, 0)));
            Assert.False(comparer.Equals(new Point(0, 0), new Point(1, 0)));
            Assert.False(comparer.Equals(new Point(0, 0), new Point(0, 1)));
        }
    }

    public class FunctionalTools : IternetTestBase
    {
        public FunctionalTools(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void converter_string_to_int()
        {
            Func<string, int> fn = (s) => int.Parse(s);

            Converter<string, int> converter = convertor(fn);

            Assert.Equal(1, converter("1"));
        }
    }
}
