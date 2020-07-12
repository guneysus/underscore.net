﻿using System;
using Xunit;
using Xunit.Abstractions;
using _ = underscore.net.Underscore;
namespace underscore.net.tests
{
    public class DateHelpersTests : UnderscoreTestBase
    {
        public DateHelpersTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Get_Date_From_Datetime()
        {
            var datetime = DateTime.Now;
            var actual = _.date(datetime);
            DateTime expected = new DateTime(datetime.Year, datetime.Month, datetime.Day);
            Assert.Equal(expected, actual);
            Assert.True(actual.Hour != datetime.Hour || actual.Minute != datetime.Minute || actual.Second != datetime.Second || actual.Millisecond != datetime.Millisecond);
        }

        [Theory]
        [InlineData(1996, 2, 29, 0, 0, 0, "29021996", "ddMMyyyy", "en-US")]
        [InlineData(2016, 3, 1, 0, 0, 0, "2016 3", "yyyy M", "en-US")]
        [InlineData(2016, 1, 12, 0, 0, 0, "2016 12", "yyyy d", "en-US")]
        [InlineData(2016, 5, 31, 13, 33, 0, "2016/31/05 13:33", "yyyy/d/M HH:mm", "en-US")]
        [InlineData(2016, 1, 31, 0, 0, 0, "2016/31 Ocak", "yyyy/d MMMM", "tr-TR")]
        [InlineData(2016, 1, 31, 0, 0, 0, "2016/31 January", "yyyy/d MMMM", "en-US")]
        [InlineData(2016, 5, 18, 0, 0, 0, "11/شعبان/1437", "dd/MMMM/yyyy", "ar-SA")]
        public void String_to_datetime_Theory(int year, int month, int day, int hour, int minute, int second, string s, string format, string cultureString)
        {
            DateTime expected = new DateTime(year, month, day, hour, minute, second);
            DateTime actual = _.Datetime(s, format: format, cultureString: cultureString);
            Assert.Equal(expected, actual);
        }
    }
}
