using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common.Logger
{
    public static class LoggerExtensionFunctions
    {

        public static void AddNLogger(this ILoggingBuilder builder)
        {
            builder.AddNLog();
        }

    }
}
