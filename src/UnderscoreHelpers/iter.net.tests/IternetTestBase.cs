using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static iter.net.Iter;
using static std.net.Std;

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

        [Fact]
        public void comparer()
        {
            IComparer<Point> comparer = comparator<Point>((a, b) => (a.X + a.Y) - (b.X + b.Y));

            Assert.Equal(0, comparer.Compare(new Point(0, 0), new Point(0, 0)));

            Assert.True(comparer.Compare(new Point(100, 0), new Point(0, 0)) > 0);
            Assert.True(comparer.Compare(new Point(0, 0), new Point(100, 0)) < 0);
        }

        [Fact]
        public void Zip_Test()
        {
            var names = list("one", "two");
            var ids = list(1, 2);
            var actual = zip(names, ids);
            var expected = list(("one", 1), ("two", 2));

            Assert.True(same(expected, actual));

            var result = zip(names.AsQueryable(), ids, (name, id) => $"{id}.{name}");

            Assert.True(same(list("1.one", "2.two"), result));
        }

        [Fact]
        public void Hashset_factory()
        {
            Assert.True(same(list(1, 2), hashset(1, 1, 2)));
        }

        [Fact]
        public void Sorted_dict_factory()
        {
            IComparer<string> comparer = comparator((string a, string b) => a == b ? 0 : -1);

            SortedDictionary<string, int> actual1 = sortedDict(comparer, ("TR", 90), ("MY", 60), ("CY", 357));
            SortedDictionary<string, int> actual2 = sortedDict(comparer, ("CY", 357), ("TR", 90), ("MY", 60));
            SortedDictionary<string, int> actual3 = sortedDict(("CY", 357), ("TR", 90), ("MY", 60));
            SortedDictionary<string, int> actual4 = sortedDict(("TR", 90), ("MY", 60), ("CY", 357));

            SortedDictionary<string, int> expected = new SortedDictionary<string, int> {
                { "TR", 90 },
                { "MY", 60 },
                { "CY", 357 }
            };

            Assert.True(same(expected, actual1));
            Assert.True(same(expected, actual2));
            Assert.True(same(expected, actual3));
            Assert.True(same(expected, actual4));
        }

        [Fact]
        public void Flatten()
        {
            Dictionary<string, List<string>> data = dict(
                ("TR#1", list("Ýstanbul", "Ýzmir", "Bursa")),
                ("TR#2", list("Konya", "Ankara", "Eskiþehir"))
            );

            IEnumerable<string> expected = list(
                "Ýstanbul", "Ýzmir", "Bursa",
                "Konya", "Ankara", "Eskiþehir"
             );

            IEnumerable<string> actual = flatten(data.Select(c => c.Value));

            Assert.True(same(expected, actual));
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
