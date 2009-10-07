namespace NETDUGSample.Entity
{
    public static class StringExtensions
    {
        public static bool HasValue(this string @string)
        {
            return !string.IsNullOrEmpty(@string);
        }
        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }
    }
}