using NLog;

namespace ProductManagement.Logger.NLog
{
    public static class NLogConfigure
    {
        public static void Config(string nlogConfigFile = "./nlog.config")
        {
            LogManager.LoadConfiguration(nlogConfigFile).GetCurrentClassLogger();
        }
    }
}