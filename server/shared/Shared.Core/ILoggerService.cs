using System;

namespace Shared.Core
{
    public interface ILoggerService
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception exception);
    }
    public interface ILoggerService<T> : ILoggerService where T : class
    {

    }
}
