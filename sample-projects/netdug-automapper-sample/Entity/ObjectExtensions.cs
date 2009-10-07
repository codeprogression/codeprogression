using System;

namespace NETDUGSample.Entity
{
    public static class ObjectExtensions
    {
        public static string ToNullSafeString(this object value)
        {
            return value == null ? String.Empty : value.ToString();
        }
    }
}