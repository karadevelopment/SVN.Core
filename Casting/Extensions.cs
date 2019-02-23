using System;
using System.Collections.Generic;
using System.Linq;

namespace SVN.Core.Casting
{
    public static class Extensions
    {
        public static T Convert<T>(this object param)
        {
            return (T)System.Convert.ChangeType(param, typeof(T));
        }

        public static List<T> ToList<T>(this Array param)
        {
            var array = (T[])param;
            var list = array.ToList();
            return list;
        }
    }
}