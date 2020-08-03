using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using __ = iter.net.Iter;

namespace iter.net.tests
{

    internal class Point
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
