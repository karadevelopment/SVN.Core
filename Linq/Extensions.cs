using System;
using System.Collections.Generic;
using System.Linq;

namespace SVN.Core.Linq
{
    public static class Extensions
    {
        public static IEnumerable<string> Split(this string param, string separator)
        {
            return param.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string Join(this IEnumerable<string> param, string separator)
        {
            return string.Join(separator, param);
        }

        public static string RemoveEmptyEntries(this string param, string separator)
        {
            return param.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).Join(separator);
        }

        public static IEnumerable<T> With<T>(this IEnumerable<T> param, T item)
        {
            var list = param.ToList();
            list.Add(item);
            return param.AsEnumerable();
        }

        public static IEnumerable<byte> Extract(this byte[] param, long index, long length)
        {
            var indexLast = System.Math.Min(length, param.Length);

            while (index < indexLast)
            {
                yield return param[index++];
            }
        }

        public static IEnumerable<byte[]> Split(this byte[] param, long interval)
        {
            var index = default(long);
            var indexLast = param.Length;

            while (index < indexLast)
            {
                var result = param.Extract(index, interval).ToArray();
                index += result.Length;
                yield return result;
            }
        }

        public static byte[] Join(this IEnumerable<byte[]> param)
        {
            var length = param.Sum(x => x.Length);
            var result = new byte[length];

            var index = default(long);
            foreach (var chunk in param)
            {
                chunk.CopyTo(result, index);
                index += length;
            }

            return result;
        }

        public static List<T> Copy<T>(this IEnumerable<T> param)
        {
            return new List<T>(param);
        }

        public static IEnumerable<T> CopyAsync<T>(this IEnumerable<T> param)
        {
            foreach (var item in new List<T>(param))
            {
                yield return item;
            }
        }

        public static void Set<T>(this ICollection<T> param, IEnumerable<T> content)
        {
            param.Clear();
            foreach (var item in content)
            {
                param.Add(item);
            }
        }

        public static void Filter<T>(this List<T> param, Func<T, bool> predicate)
        {
            param.Set(param.Where(predicate).ToList());
        }

        public static T Extract<T>(this IList<T> param)
        {
            return param.Extract(x => true);
        }

        public static T Extract<T>(this IList<T> param, Func<T, bool> predicate)
        {
            var item = param.FirstOrDefault(predicate);

            if (item != null)
            {
                param.Remove(item);
            }

            return item;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> param, Func<TSource, TKey> predicate)
        {
            var list = new HashSet<TKey>();

            foreach (var item in param)
            {
                if (list.Add(predicate(item)))
                {
                    yield return item;
                }
            }
        }

        public static void RemoveAll<T>(this ICollection<T> param, Func<T, bool> predicate)
        {
            foreach (var item in param.Where(predicate).CopyAsync())
            {
                param.Remove(item);
            }
        }
    }
}