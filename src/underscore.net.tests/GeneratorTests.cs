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

    /// <summary>
    /// Python-like generators (functions that returns IEnumerables) helpers tests. 
    /// </summary>
    public class GeneratorTests : UnderscoreTestBase
    {
        public GeneratorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Month_Names()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("tr-TR");

            IEnumerable<string> actual = _.months(culture);

            IEnumerable<string> expected = new List<string>()
            {
                "Ocak",
                "Şubat",
                "Mart",
                "Nisan",
                "Mayıs",
                "Haziran",
                "Temmuz",
                "Ağustos",
                "Eylül",
                "Ekim",
                "Kasım",
                "Aralık",
            }.AsEnumerable();

            foreach (string month in actual)
            {
                WriteLine(month);
            }

            Assert.Equal(expected, _.months(culture));
            Assert.Equal(expected, _.months("tr-TR"));
        }

        [Fact]
        public void Day_Names()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

            IEnumerable<string> expected = new List<string>()
            {
                "Monday", "Tuesday", "Wednesday", 
                "Thursday", "Friday", "Saturday", "Sunday"
            }.AsEnumerable();

            Assert.Equal(expected, _.days(culture, DayOfWeek.Monday));
            Assert.Equal(expected, _.days("en-US", DayOfWeek.Monday));
        }

        [Fact]
        public void Last_day_of_month()
        {
            DateTime date = new DateTime(2016, 12, 3);
            DateTime expected = new DateTime(2016, 12, 31);

            Assert.Equal(expected, _.lastday(date));
        }

        [Fact]
        public void Last_day_of_year()
        {
            DateTime expected = new DateTime(2016, 12, 31);

            Assert.Equal(expected, _.lastday(2016));
        }

        [Fact]
        public void First_day_of_month()
        {
            DateTime date = new DateTime(2016, 2, 29);
            DateTime expected = new DateTime(2016, 2, 1);

            Assert.Equal(expected, _.firstday(date));
        }

        [Fact]
        public void First_day_of_year()
        {
            DateTime expected = new DateTime(2016, 1, 1);

            Assert.Equal(expected, _.firstday(2016));
        }

        [Fact]
        public void Random_bytes()
        {
            byte[] bytes = _.random(16);
            WriteLine(bytes);
            Assert.NotEmpty(bytes);
        }

        [Fact]
        public void range_tests()
        {
            Assert.Equal(new int[] { 0, 1, 2, 3 }, _.range(4).ToArray());
            WriteLine(_.range(10));
            Assert.Equal(new int[] { 1, 2, 3, 4 }, _.range(1, 4).ToArray());
            Assert.Equal(new int[] { 0, 5, 10, 15 }, _.range(0, 15, 5).ToArray());
            Assert.Equal(new int[] { 0, -1, -2, -3 }, _.range(0, -3, -1).ToArray());
            Assert.Equal(new int[] { }, _.range(0).ToArray());
        }
    }
}
