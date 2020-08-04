using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static www.net.Www;
using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Rss;
using System.Globalization;

namespace www.net.tests
{
    public abstract class WwwTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public WwwTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class RssTests : WwwTestBase
    {
        public RssTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task rss_parser_tests()
        {
            string feedContent;
            const string uri = "http://feeds.feedburner.com/AmazonWebServicesBlog";
            feedContent = await HttpGetStringAsync(uri);

            if (string.IsNullOrEmpty(feedContent))
            {
                IEnumerable<RssSchema> rss = ParseRSS(feedContent);

                foreach (RssSchema element in rss)
                {
                    WriteLine($"Title: {element.Title}");
                    WriteLine($"Summary: {element.Summary}");
                }
            }

            Assert.True(true);
        }

        [Fact]
        public async Task Markdown_parse_from_urlAsync()
        {
            const string uri = "https://raw.githubusercontent.com/dotnet/sdk/master/README.md";
            string md = await HttpGetStringAsync(uri);

            MarkdownDocument document = ParseMarkdown(md);

            // Takes note of all of the Top Level Headers.
            foreach (MarkdownBlock element in document.Blocks)
            {
                WriteLine($"Element: {element.ToString()}");
                if (element is HeaderBlock header)
                {
                    WriteLine($"Header: {header.ToString()}");
                }
            }
        }
    }

    public class SlugTests : WwwTestBase
    {
        public SlugTests(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void slug_tests()
        {
            var product = " Kablosuz Bluetooth Kulaklýk - Siyah";
            var actual = slug(product, 50);
            var expected = "kablosuz-bluetooth-kulaklik---siyah…";
            Assert.Equal(expected, actual);
        }
    }

    public class UrlBuilderTests : WwwTestBase
    {
        public UrlBuilderTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void UrlBuilder_simple()
        {
            IUrlBuilder urlBuilder = new UrlBuilder()
                .SetScheme(Scheme.Https)
                .SetHost("foo.example.com")
                .SetPort(81)
                .SetPath("/about")
                ;

            var url = urlBuilder.Build();

            Assert.Equal("https://foo.example.com:81/about", url.ToString());

        }
    }

    public class PasswordGenTests : WwwTestBase
    {
        public PasswordGenTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void generate_password_1()
        {
            string pass = password(asciiall, 8);
            output.WriteLine(pass);
            Assert.NotEmpty(pass);
        }

        [Fact]
        public void generate_password2()
        {
            string pass = password(12);
            output.WriteLine(pass);
            Assert.NotEmpty(pass);
        }
    }

}
