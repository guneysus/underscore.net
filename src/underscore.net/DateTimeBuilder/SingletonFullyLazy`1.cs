using System;
using System.Globalization;

namespace underscore.net
{

    public sealed class SingletonFullyLazy<T> where T : class, new()
    {
        private SingletonFullyLazy()
        {
        }

        public static T Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly T instance = new T();
        }
    }
}
