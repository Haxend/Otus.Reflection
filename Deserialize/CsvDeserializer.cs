using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OtusCProHomework4.Deserialize
{
    public class CsvDeserializer
    {
        public T Deserialize<T>(string csv) where T : new()
        {
            var lines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var headers = lines[0].Split(',');
            var values = lines[1].Split(',');

            T obj = new T();
            var members = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance)
                                   .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property);

            for (int i = 0; i < headers.Length; i++)
            {
                var member = members.FirstOrDefault(m => m.Name == headers[i]);
                if (member != null)
                {
                    SetValue(member, obj, values[i]);
                }
            }

            return obj;
        }

        private void SetValue(MemberInfo member, object obj, string value)
        {
            switch (member)
            {
                case PropertyInfo property:
                    property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                    break;
                case FieldInfo field:
                    field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
                    break;
            }
        }
    }
}
