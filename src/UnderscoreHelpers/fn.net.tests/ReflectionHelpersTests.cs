using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using _ = fn.net.Fn;

namespace fn.net.tests
{

    public class ReflectionHelpersTests : FnTestBase
    {
        public ReflectionHelpersTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Parameterless_constructor()
        {
            var datetime = _.ctor<DateTime>()();
            Assert.Equal(new DateTime(), datetime);
        }

        [Fact]
        public void Noexisting_Constructor()
        {
            var datetime = _.ctor<string, DateTime>()("dummy-string");
            Assert.Equal(default, datetime);
        }

        [Fact]
        public void Constructors_with_parameters()
        {
            var datetime1 = _.ctor<int, int, int, DateTime>()(2006, 12, 31);
            Assert.Equal(new DateTime(2006, 12, 31), datetime1);

            var datetime2 = _.ctor<long, DateTimeKind, DateTime>()(0, DateTimeKind.Utc);
            Assert.Equal(default, datetime2);

            var datetime3 = _.ctor<int, int, int, DateTime>()(2006, 12, 31);

        }
    }


}
