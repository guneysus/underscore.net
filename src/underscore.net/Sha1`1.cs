using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace underscore.net
{

    /// <summary>
    ///
    /// credits:
    /// https://stackoverflow.com/a/415396/
    /// https://stackoverflow.com/a/10502856/
    /// https://stackoverflow.com/a/33446914/1766716
    /// https://stackoverflow.com/a/12680454/1766716
    /// https://stackoverflow.com/a/737156/1766716
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Sha1<T>
    {
        public readonly T _inner;
        Sha1() { }
        public Sha1(T inner)
        {
            _inner = inner;
        }

        public byte[] ComputeHash()
        {
            var hash = Combine(GetValueAsByteArray(_inner).ToArray());
            return Underscore.sha1(hash);
        }

        public override bool Equals(object obj)
        {
            var objHash = ((Sha1<T>)obj).ComputeHash();
            var meHash = this.ComputeHash();
            return Compare(objHash, meHash);
        }

        public override int GetHashCode()
        {
            return this.ComputeHash().GetHashCode();
        }

        public bool Compare(byte[] first, byte[] second)
        {
            if (first.Length != second.Length) return false;


            for (int i = 0; i < first.Length; i++)
                if (second[i] != first[i])
                    return false;

            return true;

        }

        public IEnumerable<byte[]> GetValueAsByteArray(T obj)
        {
            int i = -1;
            foreach (var member in GetPublicMembers(typeof(T)))
            {
                ++i;
                yield return ObjectToByteArray(GetValue(member, obj));
            }

            yield break;
        }

        public MemberInfo[] GetPublicMembers(Type type)
        {
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            return type
               .GetFields(bindingFlags)
               .Cast<MemberInfo>()
               .Concat(type.GetProperties(bindingFlags))
               .ToArray();
        }

        public object GetValue(MemberInfo memberInfo, object forObject)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(forObject);
                default:
                    throw new NotImplementedException();
            }
        }


        // Convert an object to a byte array
        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null) return new byte[0];

            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private byte[] Combine(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }
    }
}
