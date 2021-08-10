using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace CaseCore.Domain.Common
{
    public static class ExtensionMethods
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));

                        if (memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() is DescriptionAttribute descriptionAttribute)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }
            return null; // could also return string.Empty
        }
        public static string RemoveNonNumericCharacters(this string str)
        {
            return new string(str.Where(char.IsDigit).ToArray());
        }
        public static string RemoveNonAlphanumericCharacters(this string str)
        {
            return new string(str.Where(char.IsLetterOrDigit).ToArray());
        }
    }
}

