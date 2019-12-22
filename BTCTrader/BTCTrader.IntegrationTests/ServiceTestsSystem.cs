using BTCTrader.Api;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using BTCTrader.Trading.Systems;
using Serilog;

namespace BTCTrader.IntegrationTests
{
    public class ServiceTestsSystem : TradingSystem
    {
        public ServiceTestsSystem()
        {
            var jsonFileConfiguration = new JsonFileConfiguration(BTCTrader.Constants.Configuration.FILE_CONFIGURATION);
            AppSettings appSettings = jsonFileConfiguration.GetAppSettings();
            ILogger logger = jsonFileConfiguration.GetLoggerConfiguration().CreateLogger();
            ApiClient = new ApiClient(appSettings, logger);
            base.InitializeServices(ApiClient, logger);
        }
    }
}
