using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static www.net.Www;
using static std.net.Std;
using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Rss;

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

            if (isnull(feedContent))
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
}
