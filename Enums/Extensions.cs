using SVN.Core.Casting;
using System;
using System.Collections.Generic;

namespace SVN.Core.Enums
{
    public static class Extensions
    {
        public static List<T> EnumValues<T>(this Type param)
        {
            return Enum.GetValues(param).ToList<T>();
        }

        public static T ToEnum<T>(this string param)
        {
            return (T)Enum.Parse(typeof(T), param);
        }
    }
}