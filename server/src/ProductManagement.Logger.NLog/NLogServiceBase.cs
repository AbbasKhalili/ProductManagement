using NLog;

namespace ProductManagement.Logger.NLog
{
    public abstract class NLogServiceBase
    {
        private readonly ILogger _logger;

        protected NLogServiceBase(ILogger logger)
        {
            _logger = logger;
        }
        public void Information(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }
    }
}