using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace rgx.net.tests
{
    public class RgxNetTestsBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public RgxNetTestsBase(ITestOutputHelper output) => this.output = output;

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);

        protected void WriteLine<T>(IEnumerable<T> items) => output.WriteLine(string.Join(' ', items));
    }
}
