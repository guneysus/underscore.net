using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using __ = iter.net.Iter;

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

            Assert.Equal(new int[] { 1, 3, 5, 7, 9 }, __.intersect(numbers, oddNumbers));
        }

        [Fact]
        public void Intersect_with_lambda_equality_comparer()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 };
            int[] oddNumbers = new int[] { 1, 3, 5, 7, 9 };

            int[] expected = new int[] { 1, 3 };
            var comparer = __.comparer((int a, int b) => a == b && b < 5);

            IEnumerable<int> intersectedNumbersSmallerThanFive = __.intersect(numbers, oddNumbers, comparer);

            Assert.Equal(expected, intersectedNumbersSmallerThanFive);
        }

        [Fact]
        public void equality_comparer()
        {
            IEqualityComparer<Point> comparer = __.comparer<Point>((a, b) => a.X == b.X && a.Y == b.Y);

            Assert.True(comparer.Equals(new Point(0, 0), new Point(0, 0)));

            Assert.False(comparer.Equals(new Point(1, 0), new Point(0, 0)));
            Assert.False(comparer.Equals(new Point(0, 1), new Point(0, 0)));
            Assert.False(comparer.Equals(new Point(0, 0), new Point(1, 0)));
            Assert.False(comparer.Equals(new Point(0, 0), new Point(0, 1)));
        }
    }
}
