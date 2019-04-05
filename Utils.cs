namespace SVN.Core
{
    public static class Utils
    {
        public static string CreateShortIdentifier(int value)
        {
            // 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ
            // 123456789ABCDEFGHJKLMNPQRSTUVWXYZ
            // 0123456789

            var chars = "123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            var nbase = chars.Length;

            var result = string.Empty;

            while (nbase <= value)
            {
                result = chars[value % nbase] + result;
                value /= nbase;
            }
            result = chars[value % nbase] + result;

            return result;
        }
    }
}