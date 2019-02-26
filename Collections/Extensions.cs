using System;
using System.Collections.Generic;
using System.Linq;

namespace SVN.Core.Collections
{
    public static class Extensions
    {
        public static IEnumerable<T> With<T>(this IEnumerable<T> param, T item)
        {
            var result = param.ToList();
            result.Add(item);
            return result.AsEnumerable();
        }

        public static T Get<T>(this IEnumerable<T> param, int slot)
        {
            return param.ElementAtOrDefault(slot - 1);
        }

        public static T Random<T>(this IEnumerable<T> param)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var slot = random.Next(1, param.Count());
            var index = slot - 1;
            return param.ElementAt(index);
        }

        public static List<T> Invert<T>(this IEnumerable<T> param)
        {
            return param.Reverse().ToList();
        }
    }
}