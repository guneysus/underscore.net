using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static std.net.Std;
using static fn.net.Fn;
using static refl.net.Refl;
using static iter.net.Iter;

namespace std.net.tests
{
    public abstract class StdTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public StdTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class EnumTests  : StdTestBase
    {
        public EnumTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void to_enum_from_value()
        {
            const int val = (int)Day.Weekdays;
            const Day expected = Day.Weekdays;

            Day actual = parse<Day>(val);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void to_enum_from_string()
        {
            const string val = "Wednesday";
            const Day expected = Day.Wednesday;

            Day actual = parse<Day>(val);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void enum_get_names()
        {
            List<string> expected = new List<string>() { "None", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday",
            "Weekdays", "Saturday", "Sunday", "Weekend", "All"};

            List<string> actual = names<Day>().ToList();

            List<string> firstNotSecond = expected.Except(actual).ToList();
            List<string> secondNotFirst = actual.Except(expected).ToList();

            Assert.True(!firstNotSecond.Any() && !secondNotFirst.Any());
        }

        [Fact]
        public void enum_get_values()
        {
            IEnumerable<Day> actual = values<Day>();
            Assert.Equal(Day.None, actual.First());
        }
    }
}
