using System;
using System.Text.RegularExpressions;

namespace CMDAutomation.BDD.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static T ToEnumType<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), RemoveSpecialCharacters(value), true);
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
    }
}