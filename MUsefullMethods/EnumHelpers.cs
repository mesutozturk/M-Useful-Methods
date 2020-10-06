using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace MUsefulMethods
{
    public static class EnumHelpers
    {
        public static string GetDescription<T>(T item)
        {
            if (string.IsNullOrEmpty(typeof(T).GetEnumName(item))) return "";
            var descriptionAttributes = typeof(T).GetMember(typeof(T).GetEnumName(item))[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
            return ((DescriptionAttribute)descriptionAttributes).Description;
        }
        public static string GetDescriptionFromEnumValue(System.Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
        public static string GetEnumDescription(System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }

        public static Dictionary<int, string> ToKeyValuePair<TEnum>()
        {
            var dictionary = new Dictionary<int, string>();
            foreach (var item in System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList())
                dictionary.Add(System.Convert.ToInt32(item), GetDescription(item));

            return dictionary;
        }
    }
}
