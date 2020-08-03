using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static iter.net.Iter;
using _ = iter.net.Iter;
using static std.net.Std;
using std.net;

namespace iter.net.tests
{

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
        public void Is_same()
        {
            List<int> a = new List<int>() { 1, 2, 3 };
            List<int> b = new List<int>() { 2, 3, 1 };
            List<int> c = new List<int>() { 3, 2 };

            Assert.True(same(a, b));
            Assert.False(same(a, c));
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

            SortedDictionary<string, int> actual1 = sorteddict(comparer, ("TR", 90), ("MY", 60), ("CY", 357));
            SortedDictionary<string, int> actual2 = sorteddict(comparer, ("CY", 357), ("TR", 90), ("MY", 60));
            SortedDictionary<string, int> actual3 = sorteddict(("CY", 357), ("TR", 90), ("MY", 60));
            SortedDictionary<string, int> actual4 = sorteddict(("TR", 90), ("MY", 60), ("CY", 357));

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
        public void Dict_factory()
        {
            Dictionary<string, int> expected = new Dictionary<string, int> {
                { "TR", 90 },
                { "MY", 60 },
                { "CY", 357 }
            };

            Dictionary<string, int> actual = dict(
                ("TR", 90),
                ("MY", 60),
                ("CY", 357)
            );

            Assert.True(same(expected, actual));
        }

        [Fact]
        public void Flatten()
        {
            Dictionary<string, List<string>> data = dict(
                ("TR#1", list("İstanbul", "İzmir", "Bursa")),
                ("TR#2", list("Konya", "Ankara", "Eskişehir"))
            );

            IEnumerable<string> expected = list(
                "İstanbul", "İzmir", "Bursa",
                "Konya", "Ankara", "Eskişehir"
             );

            IEnumerable<string> actual = flatten(data.Select(c => c.Value));

            Assert.True(same(expected, actual));
        }

        [Fact]
        public void Sort_tests()
        {
            IComparer<Point> comparer = comparator<Point>((a, b) => (a.X + a.Y) - (b.X + b.Y));

            IEqualityComparer<Point> equalityComparer = comparator<Point>((a, b) => a.X == b.X && a.Y == b.Y);

            List<Point> data = list(
                new Point(0, 2),
                new Point(0, 0),
                new Point(0, 1)
            );

            List<Point> expected = list(
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2)
            );

            IEnumerable<Point> actual = sort(data, comparer);

            Assert.True(same(actual, expected, equalityComparer));
            Assert.True(equalityComparer.Equals(data.First(), new Point(0, 2)));
        }

        [Fact]
        public void merge_tests()
        {
            Assert.Equal(asciiletters, merge(asciilower, asciiupper));
        }


        [Fact]
        public void dict_keys()
        {
            var data = new Dictionary<string, int>
            {
                {"foo", 1 },
                {"bar", 2 },
                {"baz", 3 }
            };

            IEnumerable<string> actualKeys = keys(data);

            string actual = string.Join(';', actualKeys);
            const string expected = "foo;bar;baz";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void dict_values()
        {
            var data = new Dictionary<string, int>
            {
                {"foo", 1 },
                {"bar", 2 },
                {"baz", 3 }
            };

            const string expected = "1;2;3";
            IEnumerable<int> actualValues = values(data);
            string actual = string.Join(';', actualValues);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void dict_from_keys()
        {
            IEnumerable<string> keys = new string[] { "foo", "bar", "baz" };

            Dictionary<string, int> actual = dict<string, int>(keys);

            IEnumerable<string> result = keys.Except(actual.Keys);
            Assert.Empty(result);
        }

        [Fact]
        public void dict_merge()
        {
            var data = new Dictionary<string, int>
            {
                {"foo", 1 },
                {"bar", 2 },
                {"baz", 3 }
            };

            Dictionary<string, int> dict2 = new Dictionary<string, int>
            {
                {"lorem", 10}
            };

            Dictionary<string, int> merged = merge(data, dict2);

            IEnumerable<string> keys = merged.Keys.Except(data.Keys).Except(dict2.Keys);

            Assert.Empty(keys);
        }

        [Fact]
        public void dict_omit()
        {
            var data = new Dictionary<string, int>
            {
                {"foo", 1 },
                {"bar", 2 },
                {"baz", 3 }
            };

            const string expected = "foo:1";
            Dictionary<string, int> actualResult = omitKeys(data, "bar", "baz");

            string actual = string.Join(';', actualResult.Select(kv => $"{kv.Key}:{kv.Value}"));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void dict_omit_by()
        {
            var data = new Dictionary<string, int>
            {
                {"foo", 1 },
                {"bar", 2 },
                {"baz", 3 }
            };

            string expected = string.Empty;
            Dictionary<string, int> actualResult = omitBy(data, x => true);

            string actual = string.Join(';', actualResult.Select(kv => $"{kv.Key}:{kv.Value}"));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void dict_pick_by()
        {
            var data = new Dictionary<string, int>
            {
                {"foo", 1 },
                {"bar", 2 },
                {"baz", 3 }
            };

            const string expected = "foo:1";
            Dictionary<string, int> actualResult = pickBy(data, kv => kv.Key == "foo");

            string actual = string.Join(';', actualResult.Select(kv => $"{kv.Key}:{kv.Value}"));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void dict_pick_keys()
        {
            var data = new Dictionary<string, int>
            {
                {"foo", 1 },
                {"bar", 2 },
                {"baz", 3 }
            };

            const string expected = "foo:1;bar:2";
            Dictionary<string, int> actualResult = pickKeys(data, "foo", "bar");

            string actual = string.Join(';', actualResult.Select(kv => $"{kv.Key}:{kv.Value}"));

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void List_factory()
        {
            Assert.True(same(new List<string> { "c", "a", "b" }, list("a", "b", "c")));
        }

        [Fact]
        public void drop_tests()
        {
            var numbers = list(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var actual = drop(collection: numbers, size: 9);
            Assert.True(same(list(9), actual));
        }

        [Fact]
        public void drop_while_tests()
        {
            var numbers = list(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var evenNumbers = dropWhile(numbers, x => x % 2 != 0);
            Assert.True(same(list(0, 2, 4, 6, 8), evenNumbers));
        }
    }
}
