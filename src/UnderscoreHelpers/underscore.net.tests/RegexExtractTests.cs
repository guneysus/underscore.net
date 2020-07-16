using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using _ = underscore.net.Underscore;

namespace underscore.net.tests
{

    public class RegexExtractTests : UnderscoreTestBase
    {
        public RegexExtractTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void regex_extractor()
        {
            Func<string, IEnumerable<string>> words = _.extractor(@"\w+");

            Assert.Equal(new string[] { "Lorem", "ipsum", "dolor", "sit", "amet" }, words(@"Lorem ipsum dolor sit amet."));

            Func<string, IEnumerable<string>> ips = _.extractor(@"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");

            Assert.Equal(new string[] {
                "10.1.1.1",
                "0.0.0.0",
                "10.0.0.0",
                "100.0.0.0",
                "255.0.0.255"
            },

            ips(@"10.1.1.1
0.0.0.0
10.0.0.0
100.0.0.0
255.0.0.255"));
        }
    }
}
