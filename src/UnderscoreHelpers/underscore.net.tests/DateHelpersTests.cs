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

    public class HashToolsTests : UnderscoreTestBase
    {
        public HashToolsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void sha512_hash()
        {
            const string source = "a";
            const string expectedHash = "1F40FC92DA241694750979EE6CF582F2D5D7D28E18335DE05ABC54D0560E0F5302860C652BF08D560252AA5E74210546F369FBBBCE8C12CFC7957B2652FE9A75";

            string actualHash = _.sha512(source);
            output.WriteLine(actualHash);
            Assert.Equal(expectedHash, actualHash);
        }

        [Fact]
        public void sha256_hash()
        {
            const string source = "a";
            const string expectedHash = "CA978112CA1BBDCAFAC231B39A23DC4DA786EFF8147C4E72B9807785AFEE48BB";

            string actualHash = _.sha256(source);
            output.WriteLine(actualHash);
            Assert.Equal(expectedHash, actualHash);
        }

        [Fact]
        public void sha1_hash()
        {
            const string source = "a";
            const string expectedHash = "86F7E437FAA5A7FCE15D1DDCB9EAEAEA377667B8";

            string actualHash = _.sha1(source);
            output.WriteLine(actualHash);
            Assert.Equal(expectedHash, actualHash);
        }

        [Fact]
        public void sha384_hash()
        {
            const string source = "a";
            const string expectedHash = "54A59B9F22B0B80880D8427E548B7C23ABD873486E1F035DCE9CD697E85175033CAA88E6D57BC35EFAE0B5AFD3145F31";

            string actualHash = _.sha384(source);
            output.WriteLine(actualHash);
            Assert.Equal(expectedHash, actualHash);
        }

        [Fact]
        public void md5_hash()
        {
            const string source = "a";
            const string expectedHash = "0CC175B9C0F1B6A831C399E269772661";

            string actualHash = _.md5(source);
            output.WriteLine(actualHash);
            Assert.Equal(expectedHash, actualHash);
        }
    }
}
