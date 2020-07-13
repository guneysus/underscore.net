using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static fn.net.Fn;

namespace fn.net.tests
{
    public abstract class FnTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public FnTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class FnToolsTests : FnTestBase
    {
        public FnToolsTests(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void times_tests()
        {
            Func<int> fn = delegate () { return 10; };
            Func<int> fn2 = () => 10;
            Func<int> fn3 = () => 10;

            int[] expected = new int[] { 10, 10, 10 };

            Assert.Equal(expected.AsEnumerable(), times(3, fn));
            Assert.Equal(expected.AsEnumerable(), times(3, fn2));
            Assert.Equal(expected.AsEnumerable(), times(3, fn3));
        }

        [Fact]
        public void Chunk_Tests()
        {
            var mylist = new List<int>() { 1, 2, 3, 4, 5 };

            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{1, 2},
                new List<int>{3, 4},
                new List<int>{5},
            };

            IEnumerable<IEnumerable<int>> actual = chunk(mylist, 2);

            for (int i = 0; i < expected.Count; i++)
            {
                List<int> exp = expected[i];
                IEnumerable<int> act = actual.ElementAt(i);
                Assert.Equal(exp, act);
            }
        }

        [Fact]
        public void Apply()
        {
            Product[] products = new Product[]
            {
                new Product{ Price = 100 },
                new Product{ Price = 200 },
                new Product{ Price = 300 },
            };

            Action<Product> campaign = (p) => p.Price *= 0.95m;

            apply(products, campaign);

            Assert.Equal(95.00m, products.First().Price);
        }

        [Fact]
        public void Map()
        {
            Product[] products = new Product[]
            {
                new Product{ Price = 100 },
                new Product{ Price = 200 },
                new Product{ Price = 300 },
            };

            Func<Product, Product> campaign = (p) => new Product { Price = p.Price + 5.00m };

            IEnumerable<Product> newProducts = map(products, campaign);

            Assert.Equal(105.00m, newProducts.First().Price);
        }

        private class Product
        {
            public decimal Price { get; set; }
        }

    }


}
