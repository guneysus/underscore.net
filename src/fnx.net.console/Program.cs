using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static fnx.net.Fnx;
using static System.Console;
using static fnx.net.FnxTask;
using static math.net.MathNet;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using types;

namespace fnx.net.console
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var t = types.Color.red();

            var money = 50_000m;
            var percent10 = percentage(money)(10);

            //assemblyInfo();
            //pipesTest();
        }

        private static void assemblyInfo()
        {
            var info = refl.net.Refl.assemblyInfo(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(info);
        }


        private static void pipesTest()
        {
            Func<string> getAddress = () => "https://www.feedforall.com/sample.xml";
            Func<string, Uri> getUriFromAddress = s => new Uri(s);
            Func<HttpClient> httpClientFactory = () => new HttpClient();

            Func<Task<string>, string> getAsyncResult = task => task.ConfigureAwait(false).GetAwaiter().GetResult();

            // using block causes ThreadCancelledException
            Func<HttpClient, Uri, Task<string>> httpGet = (client, url) => client.GetStringAsync(url);

            Func<Uri, Task<string>> getRssContentByUriAsync = curry(httpGet, httpClientFactory); // or httpGet.curry(httpClientFactory)

            Func<Task<string>> getRssContentFactory = factory(httpGet, httpClientFactory, factory(getUriFromAddress, getAddress)); // or httpGet.factory(httpClientFactory, getUriFromAddress.factory(getAddress));
            Func<string, Task<string>> getRssContentByAddress = bind(getUriFromAddress, curry(httpGet, httpClientFactory)); // or .bind(httpGet.curry(httpClientFactory));
            Func<Task<string>> getRssContent = factory(getRssContentByAddress, getAddress); // or getRssContentByAddress.factory(getAddress);

            Func<string, string> getRssResultStringByAddress = bind(getRssContentByAddress, getAsyncResult);

            Func<Action<string>> getResponse1 = continueWith(getRssContent, response =>
            {
                WriteLine(response);
            }); // or getRssContent.continueWith(WriteLine)

            Func<Action<string>> getResponse2 = continueWith(getRssContent, WriteLine); // or getRssContent.continueWith(WriteLine)

            getResponse1.execute();
            getResponse2();


            WriteLine("Press Enter");
            ReadLine();
        }
    }
}

namespace fnx.net
{
    public static class Fnx
    {
        public static Func<T1, TR> bind<T1, T2, TR>(Func<T1, T2> f1, Func<T2, TR> f2) => p => f2(f1(p));
        public static Func<T1, TR> bind<T1, T2, T3, TR>(Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, TR> f3) => p => f3(f2(f1(p)));

        public static Func<T2, TR> curry<T1, T2, TR>(Func<T1, T2, TR> f, Func<T1> f1) => p => f(f1(), p);

        public static Func<T3, TR> curry<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, Func<T1> f1, Func<T2> f2) => p => f(f1(), f2(), p);
        public static Func<T2, T3, TR> curry<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, Func<T1> f1) => (p2, p3) => f(f1(), p2, p3);

        public static Func<TR> factory<T1, TR>(Func<T1, TR> f, Func<T1> f1) => () => f(f1());
        public static Func<TR> factory<T1, T2, TR>(Func<T1, T2, TR> f, Func<T1> f1, Func<T2> f2) => () => f(f1(), f2());
        public static Func<TR> factory<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, Func<T1> f1, Func<T2> f2, Func<T3> f3) => () => f(f1(), f2(), f3());

        public static Func<T1, TR> curryRight<T1, T2, TR>(Func<T1, T2, TR> f, Func<T2> f2) => p => f(p, f2());
        public static Func<T1, T2, TR> curryRight<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, Func<T3> f3) => (p1, p2) => f(p1, p2, f3());
        public static Func<T1, TR> curryRight<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, Func<T3> f3, Func<T2> f2) => p => f(p, f2(), f3());

        public static Func<TR> factoryRight<T1, TR>(Func<T1, TR> f, Func<T1> f1) => () => f(f1());
        public static Func<TR> factoryRight<T1, T2, TR>(Func<T1, T2, TR> f, Func<T2> f2, Func<T1> f1) => () => f(f1(), f2());
        public static Func<TR> factoryRight<T1, T2, T3, TR>(Func<T1, T2, T3, TR> f, Func<T3> f3, Func<T2> f2, Func<T1> f1) => () => f(f1(), f2(), f3());
    }

    public static class FnxExt
    {
        public static Func<T1, TR> bind<T1, T2, TR>(this Func<T1, T2> f1, Func<T2, TR> f2) => Fnx.bind(f1, f2);
        public static Func<T1, TR> bind<T1, T2, T3, TR>(this Func<T1, T2> f1, Func<T2, T3> f2, Func<T3, TR> f3) => Fnx.bind(f1, f2, f3);

        public static Func<T2, TR> curry<T1, T2, TR>(this Func<T1, T2, TR> f, Func<T1> f1) => Fnx.curry(f, f1);

        public static Func<T3, TR> curry<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> f, Func<T1> f1, Func<T2> f2) => Fnx.curry(f, f1, f2);
        public static Func<T2, T3, TR> curry<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> f, Func<T1> f1) => Fnx.curry(f, f1);

        public static Func<TR> factory<T1, TR>(this Func<T1, TR> f, Func<T1> f1) => Fnx.factory(f, f1);
        public static Func<TR> factory<T1, T2, TR>(this Func<T1, T2, TR> f, Func<T1> f1, Func<T2> f2) => Fnx.factory(f, f1, f2);
        public static Func<TR> factory<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> f, Func<T1> f1, Func<T2> f2, Func<T3> f3) => Fnx.factory(f, f1, f2, f3);

        public static Func<T1, TR> curryRight<T1, T2, TR>(this Func<T1, T2, TR> f, Func<T2> f2) => Fnx.curryRight(f, f2);
        public static Func<T1, T2, TR> curryRight<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> f, Func<T3> f3) => Fnx.curryRight(f, f3);
        public static Func<T1, TR> curryRight<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> f, Func<T3> f3, Func<T2> f2) => Fnx.curryRight(f, f3, f2);

        public static Func<TR> factoryRight<T1, TR>(this Func<T1, TR> f, Func<T1> f1) => Fnx.factoryRight(f, f1);
        public static Func<TR> factoryRight<T1, T2, TR>(this Func<T1, T2, TR> f, Func<T2> f2, Func<T1> f1) => Fnx.factoryRight(f, f2, f1);
        public static Func<TR> factoryRight<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> f, Func<T3> f3, Func<T2> f2, Func<T1> f1) => Fnx.factoryRight(f, f3, f2, f1);
    }

    public static class FnxTask
    {
        public static Func<Action<T>> continueWith<T>(Func<Task<T>> taskFactory, Action<T> callback)
        {
            return () =>
            {
                ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter awaiter = taskFactory().ConfigureAwait(false).GetAwaiter();
                awaiter.OnCompleted(() => callback(awaiter.GetResult()));
                return callback;
            };
        }
    }

    public static class FnxTaskExt
    {
        public static Func<Action<T>> continueWith<T>(this Func<Task<T>> taskFactory, Action<T> callback) => FnxTask.continueWith(taskFactory, callback);

        public static Action execute<T>(this Func<Action<T>> act) => () => act();
    }


}
