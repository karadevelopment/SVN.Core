using System;

namespace SVN.Core.Format
{
    public static class Extensions
    {
        private static readonly string[] BYTE_SIZES = new string[] { "B", "KB", "MB", "GB", "TB" };

        public static string FormatHHMMSS(this TimeSpan param)
        {
            return $"{param.TotalHours:N0}:{param.Minutes:D2}:{param.Seconds:D2}";
        }

        public static string FormatByteSize(this short param)
        {
            return ((long)param).FormatByteSize();
        }

        public static string FormatByteSize(this int param)
        {
            return ((long)param).FormatByteSize();
        }

        public static string FormatByteSize(this long param)
        {
            var i = default(int);
            var unit = System.Math.Pow(2, 10);

            var length = (double)param;

            while (length >= unit && i < Extensions.BYTE_SIZES.Length - 1)
            {
                i++;
                length /= unit;
            }

            return $"{length:N1} {Extensions.BYTE_SIZES[i]}";
        }
    }
}