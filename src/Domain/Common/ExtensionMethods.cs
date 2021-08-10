using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace CaseCore.Domain.Common
{
    /// <summary>
    /// Class containing extension methods used in the Domain.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns the description of an Enum as a string.
        /// </summary>
        /// <typeparam name="T">An Enum</typeparam>
        /// <param name="e"></param>
        /// <returns>A string containing the Enum's description.</returns>
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
        /// <summary>
        /// Removes non-numeric characters from a string.
        /// </summary>
        /// <param name="str">A string.</param>
        /// <returns>A new string with the non-numeric characters removed.</returns>
        public static string RemoveNonNumericCharacters(this string str)
        {
            return new string(str.Where(char.IsDigit).ToArray());
        }
        /// <summary>
        /// Removes non-alphanumeric characters from a string.
        /// </summary>
        /// <param name="str">The string to scrub.</param>
        /// <returns>A new string with non-alphanumeric characters removed.</returns>
        public static string RemoveNonAlphanumericCharacters(this string str)
        {
            return new string(str.Where(char.IsLetterOrDigit).ToArray());
        }
    }
}

