using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using _ = fn.net.Fn;

namespace fn.net.tests
{


    public class FnBindTests : FnTestBase
    {
        Func<int> gn = () => 1000;
        Func<int, string> numToStr = num => num.ToString();
        Func<string, char[]> strToArray = str => str.ToArray();
        Func<char[], IEnumerable<byte>> charArrayToByteArray = chars => chars.Select(Convert.ToByte);
        Func<IEnumerable<byte>, byte[]> toByteArray = bytes => bytes.ToArray();

        public FnBindTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void bind_two_functions()
        {

            var binded = _.bind(gn, numToStr);

            var actual = binded();
            var expected = "1000";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void bind_two_functions_1()
        {
            var binded = _.bind(numToStr, strToArray);
            var num = 1000;

            char[] actual = binded(num);
            char[] expected = new char[] { '1', '0', '0', '0' };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void bind_three_functions()
        {
            var binded = _.bind(gn, numToStr, strToArray);

            var actual = binded();
            var expected = new char[] { '1', '0', '0', '0' };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void bind_three_functions_1()
        {
            var binded = _.bind(numToStr, strToArray, charArrayToByteArray);
            var num = 1000;

            var actual = binded(num);
            var expected = new byte[] { 49, 48, 48, 48 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void bind_four_functions()
        {
            var binded = _.bind(
                gn,
                numToStr,
                strToArray,
                charArrayToByteArray);

            var actual = binded();
            var expected = new byte[] { 49, 48, 48, 48 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void bind_four_functions_1()
        {
            var binded = _.bind(
                numToStr,
                strToArray,
                charArrayToByteArray,
                values => Encoding.UTF8.GetString(values.ToArray()));

            var num = 1000;

            var actual = binded(num);
            var expected = "1000";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void bind_five_functions()
        {
            var binded = _.bind(
                gn,
                numToStr,
                strToArray,
                charArrayToByteArray,
                values => Encoding.UTF8.GetString(values.ToArray()));

            var num = 1000;

            var actual = binded();
            var expected = "1000";

            Assert.Equal(expected, actual);
        }
    }

    public class PipeTests : FnTestBase
    {
        public PipeTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void pipe_tests_with_number()
        {
            Func<int, int> incr = a => ++a;

            Assert.Equal(13, _.pipe(incr, incr, incr)(10));
        }

        [Fact]
        public void Simple_pipe()
        {
            var msg = "   lorem ipsum di amet           ";

            Func<string, string> trimSpaces = new Func<string, string>(s => s.Trim());
            Func<string, string> trimLodashes = new Func<string, string>(s => s.Trim('_'));
            Func<string, string> padRight = s => s.PadRight(30, '_');
            Func<string, string> padLeft = s => s.PadLeft(45, '_');
            Func<string, string> upper = s => s.ToUpperInvariant();

            var pipeline = _.pipe(
                trimSpaces
                , padRight
                , padLeft
                , trimLodashes
                , upper
                );

            var actual = pipeline(msg);

            WriteLine(actual);
            Assert.Equal("LOREM IPSUM DI AMET", actual);
        }
    }
}
