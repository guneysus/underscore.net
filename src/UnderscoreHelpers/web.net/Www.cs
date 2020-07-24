using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Rss;
using std.net;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static std.net.Std;

namespace www.net
{
    public static class Www
    {
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="feedContent"></param>
        /// <returns></returns>
        [Pure]
        public static IEnumerable<RssSchema> ParseRSS(string feedContent)
        {
            RssParser parser = new RssParser();
            IEnumerable<RssSchema> rss = parser.Parse(feedContent);
            return rss;
        }

        [Pure]
        public static async Task<IEnumerable<RssSchema>> FetchAndParseRSSAsync(Uri uri)
        {
            string feedContent = await HttpGetStringAsync(uri);
            RssParser parser = new RssParser();
            IEnumerable<RssSchema> rss = parser.Parse(feedContent);
            return rss;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [Pure]
        public static MarkdownDocument ParseMarkdown(string content)
        {
            MarkdownDocument document = new MarkdownDocument();
            document.Parse(content);
            return document;
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Pure]

        public static async Task<MarkdownDocument> FetchAndParseMarkdownAsync(Uri uri)
        {
            string content = await HttpGetStringAsync(uri);
            MarkdownDocument document = new MarkdownDocument();
            document.Parse(content);
            return document;
        }

        #region HTTP
        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Pure]
        public static async Task<HttpResponseMessage> HttpGetAsync(string uri)
        {
            using (HttpClient http = HttpClient())
            {
                return await http.GetAsync(uri);
            }
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Pure]
        public static async Task<HttpResponseMessage> HttpGetAsync(Uri uri)
        {
            using (HttpClient http = HttpClient())
            {
                HttpResponseMessage result = await http.GetAsync(uri);
                return result;
            }
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Pure]
        public static async Task<Stream> HttpGetStreamAsync(string uri)
        {
            using (HttpClient http = HttpClient())
            {
                return await http.GetStreamAsync(uri);
            }
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Pure]
        public static async Task<Stream> HttpGetStreamAsync(Uri uri)
        {
            using (HttpClient http = HttpClient())
            {
                Stream result = await http.GetStreamAsync(uri);
                return result;
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Pure]
        public static async Task<string> HttpGetStringAsync(Uri uri)
        {
            using (HttpClient http = HttpClient())
            {
                return await http.GetStringAsync(uri);
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Pure]
        public static async Task<string> HttpGetStringAsync(string uri)
        {
            using (HttpClient http = HttpClient())
            {
                return await http.GetStringAsync(uri);
            }
        }

        /// <summary>
        /// TODO #test #doc
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="httpContent"></param>
        /// <returns></returns>
        [Pure]
        public static async Task<HttpResponseMessage> HttpPostAsync(string uri, HttpContent httpContent)
        {
            using (HttpClient http = HttpClient())
            {
                HttpResponseMessage result = await http.PostAsync(uri, httpContent);
                return result;
            }
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <returns></returns>
        [Pure]
        public static HttpClient HttpClient()
        {
            return new HttpClient();
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        [Pure]
        public static HttpClient HttpClient(HttpMessageHandler handler)
        {
            return new HttpClient(handler);
        }

        /// <summary>
        /// TODO #test #doc
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="disposeHandler"></param>
        /// <returns></returns>
        [Pure]
        public static HttpClient HttpClient(HttpMessageHandler handler, bool disposeHandler)
        {
            return new HttpClient(handler, disposeHandler);
        }
        #endregion


        /// <summary>
        /// https://stackoverflow.com/a/2921135/1766716
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [Pure]
        public static string RemoveAccents(this string v)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(v);
            string result = Encoding.ASCII.GetString(bytes);
            return result;
        }


        [Pure]
        public static string slug(string text, int maxlength = 50)
        {
            var fns = new List<Func<string, string>>();
            fns.Add(s => s);
            fns.Add(RemoveAccents);
            fns.Add(CompactSpaces);
            fns.Add(s => new string(truncate(s, maxlength).ToArray()));
            fns.Add(LowerCase);
            fns.Add(ChangeSpacesToHypens);

            var result = fns.Aggregate(text, (s, f) => f(s));

            return result;
        }
    }


}
