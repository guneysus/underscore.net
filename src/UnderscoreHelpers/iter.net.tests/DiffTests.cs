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

    public class DiffTests : IternetTestBase
    {
        public DiffTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void diffA_list()
        {
            var first = new List<int>() { 1, 2, 3, 4, 5 };
            var second = new List<int>() { 2, 3, 4, 5, 6 };

            var diff = _.diffA(first, second);

            Assert.True(_.same(new List<int>() { 6 }, diff.Added));
            Assert.True(_.same(new List<int>() { 1 }, diff.Deleted));
            Assert.True(_.same(new List<int>() { 2, 3, 4, 5 }, diff.Same));
        }

        [Fact]
        public void diffA_dict()
        {
            var first = Std.dict(("A", 1), ("B", 2), ("C", 3));
            var second = Std.dict(("C", 3), ("B", -1), ("D", 4));

            var diff = _.diffa(first, second);

            Assert.True(_.same(Std.keyvalues(("D", 4)), diff.Added));
            Assert.True(_.same(Std.keyvalues(("A", 1)), diff.Deleted));
            Assert.True(_.same(Std.keyvalues(("B", -1)), diff.Updated));
            Assert.True(_.same(Std.keyvalues(("C", 3)), diff.Same));
        }

        [Fact]
        public void diff_list()
        {
            var first = new List<int>() { 1, 2, 3, 4, 5 };
            var second = new List<int>() { 2, 3, 4, 5, 6 };

            var diff = _.diff(first, second);

            List<(DiffType, int)> expected = new List<(DiffType, int)>() {
                (DiffType.Deleted, 1),
                (DiffType.Added, 6),
                (DiffType.Same, 2),
                (DiffType.Same, 3),
                (DiffType.Same, 5),
                (DiffType.Same, 4)
            };

            Assert.True(_.same(expected, diff));
        }

        [Fact]
        public void diff_dict()
        {
            Dictionary<string, int> first = Std.dict(("A", 1), ("B", 2), ("C", 3));
            var second = Std.dict(("C", 3), ("B", -1), ("D", 4));

            IEnumerable<(DiffType, KeyValuePair<string, int>)> diff = _.diff(first, second);

            IEnumerable<(DiffType, KeyValuePair<string, int>)> expected = Std.valuetuples(
                (DiffType.Added, Std.kv("D", 4)),
                (DiffType.Deleted, Std.kv("A", 1)),
                (DiffType.Updated, Std.kv("B", -1)),
                (DiffType.Same, Std.kv("C", 3))
            );

            Assert.True(_.same(expected, diff));
        }
    }
}
