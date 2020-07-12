﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day_Names()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("tr-TR");

            IEnumerable<string> actual = _.days(culture, DayOfWeek.Monday);

            IEnumerable<string> expected = new List<string>()
            {
                "Pazartesi",
                "Salı",
                "Çarşamba",
                "Perşembe",
                "Cuma",
                "Cumartesi",
                "Pazar"
            }.AsEnumerable();

            Assert.Equal(expected, actual);
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
            Assert.NotEmpty(bytes);
        }
    }

    public class StringHelperTests : UnderscoreTestBase
    {
        public StringHelperTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void String_to_hex()
        {
            var actual = _.hex(_.utf8bytearray("hello world")); // TODO convert to compose
            const string expected = "68656c6c6f20776f726c64";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void From_base64_to_string()
        {
            const string base64 = "aGVsbG8gd29ybGQ="; ;
            const string expected = "hello world";
            string actual = _.base64decode(base64);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void To_base64_to_string()
        {
            const string message = "hello world"; ;
            const string expected = "aGVsbG8gd29ybGQ=";
            string actual = _.base64encode(message);
            Assert.Equal(expected, actual);
        }


    }
}
