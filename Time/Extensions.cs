using System;
using System.Globalization;

namespace SVN.Core.Time
{
    public static class Extensions
    {
        public static DateTime RemoveMonths(this DateTime param)
        {
            return new DateTime(param.Year, 1, 1);
        }

        public static DateTime RemoveDays(this DateTime param)
        {
            return new DateTime(param.Year, param.Month, 1);
        }

        public static DateTime RemoveHours(this DateTime param)
        {
            return param.AddHours(-param.Hour).RemoveMinutes();
        }

        public static DateTime RemoveMinutes(this DateTime param)
        {
            return param.AddMinutes(-param.Minute).RemoveSeconds();
        }

        public static DateTime RemoveSeconds(this DateTime param)
        {
            return param.AddSeconds(-param.Second).RemoveMilliseconds();
        }

        public static DateTime RemoveMilliseconds(this DateTime param)
        {
            return param.AddMilliseconds(-param.Millisecond);
        }

        public static DateTime StartOfWeek(this DateTime param)
        {
            var diff = (param.DayOfWeek - DayOfWeek.Monday + 7) % 7;
            return param.AddDays(-diff).Date;
        }

        public static long ToTimeStamp(this DateTime? param)
        {
            return param.HasValue ? param.Value.ToTimeStamp() : DateTime.Now.ToTimeStamp();
        }

        public static long ToTimeStamp(this DateTime param)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var dateTime = new DateTime(param.Ticks, DateTimeKind.Local).ToUniversalTime();
            return (long)(dateTime - epoch).TotalMilliseconds;
        }

        public static DateTime ToDateTime(this long param)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timeSpan = TimeSpan.FromMilliseconds(param);
            return epoch.Add(timeSpan).ToLocalTime();
        }

        public static string ToTimeString(this DateTime param)
        {
            return param.ToUniversalTime().ToString("yyMMddHHmmssfff");
        }

        public static DateTime FromTimeString(this string param)
        {
            return DateTime.ParseExact(param, "yyMMddHHmmssfff", CultureInfo.InvariantCulture).ToLocalTime();
        }
    }
}