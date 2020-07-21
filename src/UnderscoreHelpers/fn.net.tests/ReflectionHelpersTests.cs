using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static fn.net.FnX;

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
            var datetime = instance<DateTime>()();
            Assert.Equal(new DateTime(), datetime);
        }

        [Fact]
        public void Noexisting_Constructor()
        {
            var datetime = instance<DateTime, string>()("dummy-string");
            Assert.Equal(default, datetime);
        }

        [Fact]
        public void Constructors_with_parameters()
        {
            var datetime1 = instance<DateTime, int, int, int>()(2006, 12, 31);
            Assert.Equal(new DateTime(2006, 12, 31), datetime1);

            var datetime2 = instance<DateTime, long, DateTimeKind>()(0, DateTimeKind.Utc);
            Assert.Equal(default, datetime2);

            var datetime3 = instance<DateTime, int, int, int>()(2006, 12, 31);

        }
    }


}
