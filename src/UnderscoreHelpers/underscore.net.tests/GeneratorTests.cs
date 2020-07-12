using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using _ = underscore.net.Underscore;

namespace underscore.net.tests
{

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

        [Fact]
        public void Last_day_of_month()
        {
            DateTime date = new DateTime(2016, 12, 3);
            DateTime expected = new DateTime(2016, 12, 31);

            Assert.Equal(expected, _.lastday(date));
        }

        [Fact]
        public void Last_day_of_year()
        {
            DateTime expected = new DateTime(2016, 12, 31);

            Assert.Equal(expected, _.lastday(2016));
        }

        [Fact]
        public void First_day_of_month()
        {
            DateTime date = new DateTime(2016, 2, 29);
            DateTime expected = new DateTime(2016, 2, 1);

            Assert.Equal(expected, _.firstday(date));
        }

        [Fact]
        public void First_day_of_year()
        {
            DateTime expected = new DateTime(2016, 1, 1);

            Assert.Equal(expected, _.firstday(2016));
        }

        [Fact]
        public void Random_bytes()
        {
            byte[] bytes = _.random(16);
            Assert.NotEmpty(bytes);
        }

        [Fact]
        public void range_tests()
        {
            Assert.Equal(new int[] { 0, 1, 2, 3 }, _.range(4).ToArray());
            Assert.Equal(new int[] { 1, 2, 3, 4 }, _.range(1, 4).ToArray());
            Assert.Equal(new int[] { 0, 5, 10, 15 }, _.range(0, 15, 5).ToArray());
            Assert.Equal(new int[] { 0, -1, -2, -3 }, _.range(0, -3, -1).ToArray());
            Assert.Equal(new int[] { }, _.range(0).ToArray());
        }
    }

    public class StringHelperTests : UnderscoreTestBase
    {
        public StringHelperTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void String_to_hex()
        {
            var actual = _.hex(_.utf8bytearray("hello world")); // TODO convert to compose
            const string expected = "68656c6c6f20776f726c64";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void From_base64_to_string()
        {
            const string base64 = "aGVsbG8gd29ybGQ="; ;
            const string expected = "hello world";
            string actual = _.base64decode(base64);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void To_base64_to_string()
        {
            const string message = "hello world"; ;
            const string expected = "aGVsbG8gd29ybGQ=";
            string actual = _.base64encode(message);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Gzip_Compress()
        {
            var text = "StringStringStringStringStringStringStringStringStringStringStringStringStringString";
            var compressedData = _.compress(text);
            var decommpressedData = _.decompress(compressedData);

            double compressionRatio = Convert.ToDouble(Encoding.Unicode.GetByteCount(text)) / Convert.ToDouble(compressedData.LongLength);

            Assert.True(compressionRatio > 1.0d);
            Assert.Equal(text, decommpressedData);
        }

        [Fact]
        public void Strip()
        {
            const string source = "0C-C1-75-B9-C0-F1-B6-A8-31-C3-99-E2-69-77-26-61";
            const string expcected = "0CC175B9C0F1B6A831C399E269772661";

            string actual = _.strip(source, "-");

            Assert.Equal(expcected, actual);
        }



        [Fact]
        public void capitalize()
        {
            const string Expected = "Fred";
            Assert.Equal(Expected, _.capitalize("FRED"));
            Assert.Equal(Expected, _.capitalize("fred"));
            Assert.Equal(Expected, _.capitalize("frEd"));
            Assert.Equal(Expected, _.capitalize("frED"));
            Assert.Equal(string.Empty, _.capitalize(string.Empty));
            Assert.Throws<ArgumentNullException>(() =>
            {
                _.capitalize(null);
            });
        }

        [Fact]
        public void deburr()
        {
            const string Expected = "deja vu";

            Assert.Equal(Expected, _.deburr("déjà vu"));
        }

        [Fact]
        public void escape()
        {
            const string Expected = "fred, barney, &amp; pebbles";

            Assert.Equal(Expected, _.escape("fred, barney, & pebbles"));
        }

        [Fact]
        public void unescape()
        {
            const string Expected = "fred, barney, & pebbles";

            Assert.Equal(Expected, _.unescape("fred, barney, &amp; pebbles"));
        }

        [Theory]
        [InlineData("***", '*', 3)]

        public void repeat(string expected, char c, int count)
        {
            Assert.Equal(expected, _.repeat(c, count));
            Assert.Throws<ArgumentOutOfRangeException>(() => _.repeat('-', int.MinValue));
        }

        [Theory]
        [InlineData("ffffff", "ff", 3)]

        public void repeat_str(string expected, string s, int count)
        {
            Assert.Equal(expected, _.repeat(s, count));
        }

        [Theory]
        [InlineData("abc", 'a', 'b', 'c')]
        [InlineData("0xff", '0', 'x', 'f', 'f')]
        public void concat_char(string expected, params char[] args)
        {
            Assert.Equal(expected, _.concat(args));
        }

        [Theory]
        [InlineData("abc", "a", "bc")]
        public void concat_str(string expected, params string[] args)
        {
            Assert.Equal(expected, _.concat(args));
        }

    }

    public class Validators : UnderscoreTestBase
    {
        public Validators(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("lorem@example.com", true)]
        [InlineData("lorem@example.co.uk", true)]
        public void email(string s, bool expected)
        {
            Assert.Equal(expected, _.email(s));
        }
    }

    public class StreamHelperTests : UnderscoreTestBase
    {
        public StreamHelperTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Read_stream_as_string()
        {
            const string message = "Hello World";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(message));
            string s = _.read(stream);
            Assert.Equal(expected: message, actual: s);
        }
    }
}
