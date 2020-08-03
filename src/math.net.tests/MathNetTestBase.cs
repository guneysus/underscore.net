using System;
using Xunit;
using Xunit.Abstractions;
using _ = math.net.MathNet;

namespace math.net.tests
{
    public abstract class MathNetTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public MathNetTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }
}
