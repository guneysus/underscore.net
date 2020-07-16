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
