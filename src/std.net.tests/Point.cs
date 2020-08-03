using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static std.net.Std;
using static fn.net.Fn;
using static refl.net.Refl;
using static iter.net.Iter;


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