using BTCTrader.Entities;
using Serilog;

namespace BTCTrader.Configuration
{
    public interface ITradingSystemConfiguration
    {
        AppSettings GetAppSettings();
        LoggerConfiguration GetLoggerConfiguration();
    }
}