using NLog;

namespace CI.Common.Logger
{
    public class Log<T> where T : new()
    {
        private static ILogger log;

        static Log()
        {            
            log = new LogFactory().GetLogger(typeof(T).Name);
        }

        public static void Debug(object message)
        {
            log.Debug(message);
        }

        //TODO:待调整

        //public static void Debug(object message, Exception exception)
        //{
        //    log.Debug(message, exception);
        //}

        public static void Debug(object message, params object[] args)
        {
            log.Debug(string.Format(message.ToString(), args));
        }

        public static void Error(object message)
        {
            log.Error(message);
        }

        //public static void Error(object message, Exception exception)
        //{
        //    log.Error(message, exception);
        //}

        public static void Error(object message, params object[] args)
        {
            log.Error(string.Format(message.ToString(), args));
        }

        public static void Fatal(object message)
        {
            log.Fatal(message);
        }

        //public static void Fatal(object message, Exception exception)
        //{
        //    log.Fatal(message, exception);
        //}

        public static void Fatal(object message, params object[] args)
        {
            log.Fatal(string.Format(message.ToString(), args));
        }

        public static void Info(object message)
        {
            log.Info(message);
        }

        //public static void Info(object message, Exception exception)
        //{
        //    log.Info(message, exception);
        //}

        public static void Info(object message, params object[] args)
        {
            log.Info(string.Format(message.ToString(), args));
        }

        public static void Warn(object message)
        {
            log.Warn(message);
        }

        //public static void Warn(object message, Exception exception)
        //{
        //    log.Warn(message, exception);
        //}

        public static void Warn(object message, params object[] args)
        {
            log.Warn(string.Format(message.ToString(), args));
        }

    }
}
