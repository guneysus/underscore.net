using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using _ = underscore.net.Underscore;

namespace underscore.net.tests
{

    public class CoreTests : UnderscoreTestBase
    {
        public CoreTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void clone_list()
        {
            List<int> list = new List<int>() { 1, 2, 3 };
            List<int> actualList = _.clone(list);
            Assert.Equal(list, actualList);
        }

        [Fact]
        public void clone_object()
        {
            var obj = new object();

            var newObj = _.clone(obj);
            Assert.NotEqual(obj, newObj);
        }

        [Fact]
        public void new_instance()
        {
            Assert.Equal(default, _.create<DateTime>());
        }
    }
}
