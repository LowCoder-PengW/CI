using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common.Web
{
    internal class Utils
    {
        protected static string __RunningEnvironment;

        public static bool IsDevelopment
        {
            get
            {
                if (string.IsNullOrEmpty(__RunningEnvironment))
                {
                    __RunningEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                }

                return "Development".Equals(__RunningEnvironment);
            }
        }

        public static bool EnableConsoleLog()
        {
            return "true".Equals(Environment.GetEnvironmentVariable("EnableConsoleLog"), StringComparison.OrdinalIgnoreCase);
        }

        public static void WriteConsole(string s)
        {
            if (IsDevelopment && EnableConsoleLog())
            {
                Console.WriteLine(s);
            }
        }

        public static long? TryParseLong(string s, long? defaultValue = null)
        {
            if (long.TryParse(s, out var result))
            {
                return result;
            }

            return defaultValue;
        }

        public static int? TryParseInt(string s, int? defaultValue = null)
        {
            if (int.TryParse(s, out var result))
            {
                return result;
            }

            return defaultValue;
        }

    }
}
