using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace refl.net
{
    public static class Refl
    {
        [Pure]
        public static TResult value<T, TResult>(T obj, string name)
        {
            return (TResult)prop<T, TResult>(name).GetValue(obj);
        }

        public static PropertyInfo prop<T, TResult>(string name)
        {
            return typeof(T).GetProperty(name, typeof(TResult));
        }

        /// <summary>
        /// https://stackoverflow.com/a/12294308/1766716
        /// </summary>
        /// <param name="target"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static T Set<T, TValue>(T obj, string name, TValue value)
        {
            object target = obj;
            string[] bits = name.Split('.');

            for (int i = 0; i < bits.Length - 1; i++)
            {
                string propName = bits[i];
                PropertyInfo prop = target.GetType().GetProperty(propName);
                target = prop.GetValue(target, null);
            }

            string propNameLast = bits.Last();
            PropertyInfo propertyToSet = target.GetType().GetProperty(propNameLast);

            if (!propertyToSet.PropertyType.Equals(typeof(TValue)))
            {
                throw new ArgumentException($"{nameof(value)} must be in type {typeof(TValue)};");
            }

            propertyToSet.SetValue(obj: target, value: value, index: null);

            return obj;
        }

    }

}
