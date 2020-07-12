using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        public void Get_date_from_datetime()
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
            DateTime actual = _.datetime(s, format: format, cultureString: cultureString);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2000, 1, 1, 0, 0, 0, 946684800, DateTimeKind.Unspecified)]
        [InlineData(2000, 1, 1, 0, 0, 0, 946684800, DateTimeKind.Utc)]
        public void From_unix_timestamp(int year, int month, int day, int hour, int minute, int second, long seconds, DateTimeKind kind)
        {
            DateTime expected = new DateTime(year, month, day, hour, minute, second, kind);
            DateTime actual = _.datetime(seconds, kind);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2000, 1, 1, 0, 0, 0, 946684800, DateTimeKind.Utc)]
        public void To_Unixtimestamp(int year, int month, int day, int hour, int minute, int second, long expected, DateTimeKind kind)
        {
            DateTime date = new DateTime(year, month, day, hour, minute, second, kind);
            int actual = _.timestamp(date);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(2000, 1, 13, 0, 0, 0, DateTimeKind.Local, 947714400000)]
        public void UnixTime_Milliseconds(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind, long expected)
        {
            var actual = _.miliseconds(new DateTime(year, month, day, hour, minute, second, kind));
            Assert.Equal(expected, actual);
        }
    }

    /// <summary>
    /// Python-like generators (functions that returns IEnumerables) helpers tests. 
    /// </summary>
    public class GeneratorTests : UnderscoreTestBase
    {
        public GeneratorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Month_Names()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("tr-TR");

            IEnumerable<string> actual = _.months(culture);

            IEnumerable<string> expected = new List<string>()
            {
                "Ocak",
                "Şubat",
                "Mart",
                "Nisan",
                "Mayıs",
                "Haziran",
                "Temmuz",
                "Ağustos",
                "Eylül",
                "Ekim",
                "Kasım",
                "Aralık",
            }.AsEnumerable();

            foreach (string month in actual)
            {
                WriteLine(month);
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day_Names()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("tr-TR");

            IEnumerable<string> actual = _.days(culture, DayOfWeek.Monday);

            IEnumerable<string> expected = new List<string>()
            {
                "Pazartesi",
                "Salı",
                "Çarşamba",
                "Perşembe",
                "Cuma",
                "Cumartesi",
                "Pazar"
            }.AsEnumerable();

            Assert.Equal(expected, actual);
        }
    }
}
