using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace fs.net.tests
{
    public class FsNetTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public FsNetTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);

        protected void WriteLine(IEnumerable<byte> items) => output.WriteLine(string.Join(' ', items));
        protected void WriteLine(IEnumerable<int> items) => output.WriteLine(string.Join(' ', items));
    }
}
