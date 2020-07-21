using System;
using Xunit;
using Xunit.Abstractions;
using _ = concurrent.net.Conc;

namespace concurrent.net.tests
{
    public abstract class ConcurrentNetTestBase
    {
        protected readonly ITestOutputHelper output;

        public ConcurrentNetTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }
    }

    public class LazyTests : ConcurrentNetTestBase
    {
        public LazyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Simple_lazy_tests()
        {
            var panda = _.lazy(() => new Panda());
        }

        class Panda
        {

        }
    }
}
