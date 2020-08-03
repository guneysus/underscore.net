using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace std.net
{

    [Flags]
    public enum Day
    {
        None = 0,

        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,

        Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,

        Saturday = 32,
        Sunday = 64,

        Weekend = Sunday | Saturday,

        All = Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday,
    }
}

