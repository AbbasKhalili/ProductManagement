using Shared.Core;
using NLog;

namespace ProductManagement.Logger.NLog
{
    public class NLoggerService : NLogServiceBase, ILoggerService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public NLoggerService() : base(Logger)
        {
        }
    }

    public class NLoggerService<T> : NLogServiceBase, ILoggerService<T> where T : class
    {
        private static readonly ILogger Logger = LogManager.LogFactory.GetLogger(typeof(T).FullName);

        public NLoggerService() : base(Logger)
        {

        }
    }
}
