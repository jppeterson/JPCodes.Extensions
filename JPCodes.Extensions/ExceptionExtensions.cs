using System;
using System.Collections.Generic;
using System.Text;

namespace JPCodes.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Return a string print of all messages and inner exceptions.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string Print(this Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            Exception inner = ex.InnerException;
            while (inner != null)
            {
                sb.AppendLine("======INNER EXCEPTION======");
                sb.AppendLine(inner.Message);
                sb.AppendLine(inner.StackTrace);
                inner = inner.InnerException;
            }
            return sb.ToString();
        }
    }
}
