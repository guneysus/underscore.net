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

    public class TypeConvertTests : UnderscoreTestBase
    {
        public TypeConvertTests(ITestOutputHelper output) : base(output)
        {
        }


        [Theory]
        [InlineData("1", true)]
        [InlineData("True", true)]
        [InlineData("False", false)]
        [InlineData("no", false)]
        [InlineData("yes", true)]
        [InlineData("on", true)]
        [InlineData("checked", true)]
        public void to_bool(string v, bool expected)
        {
            Assert.Equal(expected, _.boolean(v));
        }
        
        [Fact]
        public void to_bool_user_defined()
        {
            Assert.True(_.boolean("open", trueValues: "open"));
            Assert.False(_.boolean("closed", trueValues: "open"));
        }
    }
}
