using Xunit.Abstractions;
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
    }
}
