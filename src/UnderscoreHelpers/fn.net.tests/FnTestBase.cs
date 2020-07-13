using System;
using Xunit;
using Xunit.Abstractions;

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
}
