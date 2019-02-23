using System.Collections.Generic;
using System.Linq;

namespace SVN.Core.Collections
{
    public static class Extensions
    {
        public static IEnumerable<T> Add<T>(this IEnumerable<T> param, T item)
        {
            var result = param.ToList();
            result.Add(item);
            return result.AsEnumerable();
        }
    }
}