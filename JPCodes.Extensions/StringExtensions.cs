﻿using System;

#nullable enable
namespace JPCodes.Extensions
{
    public static class StringExtensions
    {
        public static bool? ToBool(this string s)
        {
            if (bool.TryParse(s, out bool b))
            {
                return b;
            }
            return null;
        }

        public static decimal? ToDecimal(this string s)
        {
            if (decimal.TryParse(s, out decimal b))
            {
                return b;
            }
            return null;
        }

        public static int? ToInt(this string s)
        {
            if (int.TryParse(s, out int result))
            {
                return result;
            }
            return null;
        }

        public static long? ToLong(this string s)
        {
            if (long.TryParse(s, out long result))
            {
                return result;
            }
            return null;
        }

        public static Guid? ToGuid(this string s)
        {
            if (Guid.TryParse(s, out Guid result))
            {
                return result;
            }
            return null;
        }

        public static DateTime? ToDateTime(this string s)
        {
            if (DateTime.TryParse(s, out DateTime result))
            {
                return result;
            }
            return null;
        }
    }
}