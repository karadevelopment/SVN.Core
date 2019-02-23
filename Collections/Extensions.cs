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
    }
}