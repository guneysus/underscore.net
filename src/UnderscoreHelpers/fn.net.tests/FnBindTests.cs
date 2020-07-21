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
}
