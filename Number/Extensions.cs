using System;

namespace SVN.Core.Number
{
    public static class Extensions
    {
        public static byte Limit(this byte param, byte min, byte max)
        {
            param = Math.Max(param, min);
            param = Math.Min(param, max);
            return param;
        }
        
        public static short Limit(this short param, short min, short max)
        {
            param = Math.Max(param, min);
            param = Math.Min(param, max);
            return param;
        }

        public static int Limit(this int param, int min, int max)
        {
            param = Math.Max(param, min);
            param = Math.Min(param, max);
            return param;
        }

        public static long Limit(this long param, long min, long max)
        {
            param = Math.Max(param, min);
            param = Math.Min(param, max);
            return param;
        }

        public static float Limit(this float param, float min, float max)
        {
            param = Math.Max(param, min);
            param = Math.Min(param, max);
            return param;
        }

        public static double Limit(this double param, double min, double max)
        {
            param = Math.Max(param, min);
            param = Math.Min(param, max);
            return param;
        }

        public static decimal Limit(this decimal param, decimal min, decimal max)
        {
            param = Math.Max(param, min);
            param = Math.Min(param, max);
            return param;
        }

        public static byte Approach(this byte param, byte approximation)
        {
            var value = (double)param;
            return (byte)value.Approach(approximation);
        }

        public static short Approach(this short param, short approximation)
        {
            var value = (double)param;
            return (short)value.Approach(approximation);
        }

        public static int Approach(this int param, int approximation)
        {
            var value = (double)param;
            return (int)value.Approach(approximation);
        }

        public static double Approach(this double param, double approximation)
        {
            return param * .9 + approximation * .1;
        }
    }
}