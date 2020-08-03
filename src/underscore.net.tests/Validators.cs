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

        [Theory]
        [InlineData("545-231-5566", true)]
        [InlineData("545 231 55 66", true)]
        [InlineData("545231 55 66", true)]
        [InlineData("54523155 66", true)]
        [InlineData("5452315566", true)]
        [InlineData("545-2315566", true)]
        [InlineData("545-231-55-66", true)]
        [InlineData("545 231-55-66", true)]
        [InlineData("545 231 5566", true)]
        [InlineData("0545 231 5566", true)]
        [InlineData("05452315566", true)]
        [InlineData("0545231 5566", true)]
        [InlineData("+90 545231 5566", true)]
        [InlineData("+90 545 231 5566", true)]
        [InlineData("+90 545 231 55 66", true)]
        [InlineData("+90-545-231-55-66", true)]
        [InlineData("+90545-231-55-66", true)]
        [InlineData("+90545-XXX-XX-XX", false)]
        [InlineData("+90545-XXX-XXXX", false)]
        [InlineData("+90545-XXX-ABCD", false)]
        [InlineData("+90545XXXABCD", false)]
        [InlineData("(987) 654-3210", true)]
        [InlineData("(987)654-3210", true)]
        [InlineData("987-654-3210", true)]
        [InlineData("9876543210", true)]
        [InlineData("+1 9876543210", true)]
        [InlineData("001 9876543210", true)]
        [InlineData("001 987-654-3210", true)]
        [InlineData("19876543210", true)]
        [InlineData("1-987-654-3210", true)]
        public void Is_phone_number(string number, bool expected)
        {
            Assert.Equal(expected, _.phone(number));
        }

        [Theory]
        [InlineData("255.0.0.0", true)]
        [InlineData("255.0.0.256", false)]
        public void Is_ip(string input, bool expected)
        {
            Assert.Equal(expected, _.ip(input));
        }
    }
}
