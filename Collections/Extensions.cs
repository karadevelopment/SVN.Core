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
            var slot = random.Next(1, param.Count() + 1);
            var index = slot - 1;
            return param.ElementAt(index);
        }

        private static IEnumerable<T> RandomizeAsync<T>(this IEnumerable<T> param, int index1, int index2)
        {
            for (var index = default(int); index <= index1 - 1; index++)
            {
                yield return param.ElementAt(index);
            }
            foreach (var value in param.ToList().GetRange(index1, index2 - index1 + 1).OrderBy(x => Guid.NewGuid()))
            {
                yield return value;
            }
            for (var index = index2 + 1; index <= param.Count() - 1; index++)
            {
                yield return param.ElementAt(index);
            }
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> param)
        {
            return param.RandomizeAsync(-1, -1).ToList();
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> param, int index1, int index2)
        {
            index2 = Math.Max(index1, index2);
            return param.RandomizeAsync(index1, index2).ToList();
        }

        public static List<T> Invert<T>(this IEnumerable<T> param)
        {
            return param.Reverse().ToList();
        }
    }
}