using System.Linq;

namespace SVN.Core.String
{
    public static class Extensions
    {
        public static bool Contains(this string param, params string[] values)
        {
            return values.All(x => param.Contains(x));
        }

        public static bool HasChar(this string param, int index, char value)
        {
            return index <= param.Length - 1 && param[index] == value;
        }

        public static bool HasCharFirst(this string param, char value)
        {
            return param.HasChar(0, value);
        }

        public static bool HasCharLast(this string param, char value)
        {
            return param.HasChar(param.Length - 1, value);
        }

        public static string Copy(this string param, int index, int length)
        {
            var result = string.Empty;

            for (var i = 1; i <= length; i++)
            {
                if (param.Length - 1 < index + i - 1)
                {
                    return result;
                }

                result += param[index + i - 1];
            }

            return result;
        }

        public static string Copy(this string param, int index, char value, int additionalLength = 0)
        {
            return param.Copy(index, param.IndexOf(value) - index + additionalLength);
        }

        public static string Trim(this string param, int length)
        {
            return param.TrimStart(length).TrimEnd(length);
        }

        public static string TrimStart(this string param, int length)
        {
            for (var i = 1; i <= length; i++)
            {
                if (param.Any())
                {
                    param = param.Remove(0, 1);
                }
            }
            return param;
        }

        public static string TrimMiddle(this string param, int index, int length)
        {
            var result = param;

            for (var i = 1; i <= length; i++)
            {
                if (param.Length - 1 < index + i - 1)
                {
                    return result;
                }

                result = result.Remove(index, 1);
            }

            return result;
        }

        public static string TrimEnd(this string param, int length)
        {
            for (var i = 1; i <= length; i++)
            {
                if (param.Any())
                {
                    param = param.Remove(param.Length - 1, 1);
                }
            }
            return param;
        }

        public static string Remove(this string param, string value)
        {
            return param.Replace(value, string.Empty);
        }

        public static string Remove(this string param, string startValue, string endValue)
        {
            while (param.Contains(startValue) && param.Contains(endValue))
            {
                var index1 = param.IndexOf(startValue);
                var index2 = param.IndexOf(endValue) + endValue.Length;
                var part1 = param.Substring(0, index1);
                var part2 = param.Remove(0, index2);
                param = part1 + part2;
            }
            return param;
        }

        public static string Remove(this string param, int index, int length)
        {
            var result = param;

            for (var i = 1; i <= length; i++)
            {
                if (param.Length - 1 < index + i - 1)
                {
                    return result;
                }

                result = result.Remove(index, 1);
            }

            return result;
        }

        public static string Remove(this string param, int index, char value, int additionalLength = 0)
        {
            return Extensions.Remove(param, index, param.IndexOf(value) - index + additionalLength);
        }
    }
}