using System;
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
    }
}
