using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;
using _ = underscore.net.Underscore;
using underscore.net;

namespace underscore.net.tests
{


    public class DateTimeBuilderTests : UnderscoreTestBase
    {
        public DateTimeBuilderTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Datetime_builder_simple_tests()
        {
            var actual = _.datetime()
                .Calendar(new GregorianCalendar())
                .Year(2020)
                .Month(1)
                .Day(22)
                .Hour(16)
                .Minute(50)
                .Second(59)
                .Milisecond(999)
                .Kind(DateTimeKind.Local)
                .TimeZone(TimeZoneInfo.Utc)
                .Build()
                ;

            DateTime expected = new DateTime(2020, 1, 22, 13, 50, 59, 999, DateTimeKind.Utc);

            Assert.Equal(expected, actual);

            return; // TODO
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(1891));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(1900).Month(13));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(1900).Month(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2020).Month(1).Day(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2020).Month(1).Day(31));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2016).Month(2).Day(30));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2015).Month(2).Day(29));
        }

        [Fact]
        public void Datetime_builder_with_extension_methods()
        {
            var actual = _.datetime()
                .calendar(new GregorianCalendar())
                .year(2020)
                .month(1)
                .day(22)
                .hour(16)
                .minute(50)
                .second(59)
                .milisecond(999)
                .kind(DateTimeKind.Local)
                .timezone(TimeZoneInfo.Utc)
                .build()
                ;

            DateTime expected = new DateTime(2020, 1, 22, 13, 50, 59, 999, DateTimeKind.Utc);

            Assert.Equal(expected, actual);
            return; // TODO

            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(1891));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(1900).Month(13));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(1900).Month(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2020).Month(1).Day(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2020).Month(1).Day(31));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2016).Month(2).Day(30));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.datetime().Calendar(new GregorianCalendar()).Year(2015).Month(2).Day(29));
        }
    }
}
