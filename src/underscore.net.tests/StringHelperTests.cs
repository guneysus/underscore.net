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

    public class StringHelperTests : UnderscoreTestBase
    {
        public StringHelperTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void String_to_hex()
        {
            var actual = _.hex(new byte[] { 255, 200 }); // TODO convert to compose
            const string expected = "ffc8";
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
            var text = "StringStringStringStringStringStringString";
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
            const string Expected = "Ahmet şerif izgören";
            Assert.Equal(Expected, _.capitalize("AHMET ŞERİF İZGÖREN"));
            Assert.Equal(Expected, _.capitalize("ahmeT şerif izGöReN"));
            Assert.Equal(Expected, _.capitalize("ahmET şErİf İzGÖReN"));
            Assert.Equal(Expected, _.capitalize("ahmeT ŞERiF izGöReN"));
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
}
