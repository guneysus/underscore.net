using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using _ = underscore.net.Underscore;

namespace underscore.net.tests
{

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
