using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using _ = underscore.net.Underscore;

namespace underscore.net.tests
{
    public abstract class UnderscoreTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public UnderscoreTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);


        protected void WriteLine(IEnumerable<byte> items)
        {
            output.WriteLine(string.Join(' ', items));
        }
        protected void WriteLine(IEnumerable<int> items)
        {
            output.WriteLine(string.Join(' ', items));
        }
    }
}
