using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OtusCProHomework4.Serialize
{
    public class CsvSerializer
    {
        public string Serialize<T>(T obj)
        {
            var type = typeof(T);
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
                              .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property);

            var csvBuilder = new StringBuilder();

            // Headers
            csvBuilder.AppendLine(string.Join(",", members.Select(m => m.Name)));

            // Values
            csvBuilder.AppendLine(string.Join(",", members.Select(m => GetValue(m, obj))));

            return csvBuilder.ToString();
        }

        private static object GetValue(MemberInfo member, object obj)
        {
            return member.MemberType switch
            {
                MemberTypes.Field => ((FieldInfo)member).GetValue(obj),
                MemberTypes.Property => ((PropertyInfo)member).GetValue(obj),
                _ => throw new InvalidOperationException("Unsupported member type")
            };
        }
    }
}