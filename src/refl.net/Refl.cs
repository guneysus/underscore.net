using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

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

        public static AssemblyReflInfo assemblyInfo(string path)
        {

            if (!File.Exists(path)) throw new FileNotFoundException("Assembly File not found", path);

            var asm = Assembly.LoadFile(path);

            var result = new AssemblyReflInfo
            {
                Name = asm.GetName().Name,
                FullName = asm.FullName
            };


            foreach (var _module in asm.GetModules())
            {
                var mod = new ModuleReflInfo
                {
                    Name = _module.Name,
                    FullName = _module.FullyQualifiedName
                };

                result.Modules.Add(mod);

                foreach (var _type in _module.GetTypes())
                {
                    var type = new TypeReflInfo
                    {
                        Name = _type.Name,
                        FullName = _type.FullName,
                    };

                    mod.Types.Add(type);

                    foreach (var _method in _type.GetMethods())
                    {
                        var method = new MethodReflInfo()
                        {
                            Name = _method.Name,
                            GenericArguments = string.Join(",", _method.GetGenericArguments().Select(getTypeString)),
                            ReturnType = getTypeString(_method.ReturnType),
                            Parameters = _method.GetParameters().Select(x => new ParamReflInfo()
                            {
                                Name = x.Name,
                                TypeName = getTypeString(x.ParameterType)
                            }).ToList()
                        };

                        type.Methods.Add(method);
                    }
                }
            }

            return result;
        }

        public static string getTypeString(Type type)
        {
            var sb = new StringBuilder();

            if (type.IsConstructedGenericType)
            {
                sb.Append(type.Name.Substring(0, type.Name.IndexOf('`')));
                sb.Append('<');
                string value = string.Join(", ", type.GenericTypeArguments.Select(getTypeString));
                sb.Append(value);
                sb.Append('>');
            }

            if (type.IsGenericParameter)
            {
                sb.Append(type.Name);
            }

            if (sb.Length == 0)
            {
                return type.FullName;
            }

            string result = sb.ToString();
            return result;
        }
    }


    public class AssemblyReflInfo : IReflectionInfo
    {

        public List<ModuleReflInfo> Modules { get; set; } = new List<ModuleReflInfo>();
        public string Name { get; set; }
        public string FullName { get; set; }

        public override string ToString() => string.Join(Environment.NewLine,
                $"{FullName}",
                string.Join(string.Empty, Enumerable.Repeat('-', FullName.Length)),
                string.Join(Environment.NewLine, Modules.Select(module => $"{module}")),
                Environment.NewLine
                );
    }


    public class ModuleReflInfo : IReflectionInfo
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public List<TypeReflInfo> Types { get; set; } = new List<TypeReflInfo>();
        public override string ToString() => string.Join(Environment.NewLine,
            $"{FullName}",
            string.Join(string.Empty, Enumerable.Repeat('-', FullName.Length)),
            string.Join(Environment.NewLine, Types.Select(type => $"{type}")),
            Environment.NewLine
            );
    }

    public class TypeReflInfo : IReflectionInfo
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public List<MethodReflInfo> Methods { get; set; } = new List<MethodReflInfo>();

        public override string ToString() => string.Join(Environment.NewLine,
            $"{FullName}",
            string.Join(string.Empty, Enumerable.Repeat('-', FullName.Length)),
            string.Join(Environment.NewLine, Methods.Select(type => $"{type}")),
            Environment.NewLine
            );

    }

    public class MethodReflInfo : IReflInfo
    {
        public string Name { get; set; }
        public string GenericArguments { get; set; }
        public string ReturnType { get; set; }
        public List<ParamReflInfo> Parameters { get; set; } = new List<ParamReflInfo>();

        public override string ToString() => string.Concat(ReturnType, " ", Name,
            string.IsNullOrEmpty(GenericArguments)
            ? string.Empty
            : string.Concat('<', GenericArguments, '>')
            , "(", string.Join(",", Parameters), ");");
    }

    public class ParamReflInfo : IReflInfo
    {
        public string Name { get; set; }
        public string TypeName { get; set; }

        public override string ToString() => string.Concat(TypeName, " ", Name);
    }

    public interface IReflectionInfo : IReflInfo
    {
        string FullName { get; set; }
    }

    public interface IReflInfo
    {
        string Name { get; set; }

    }

}
