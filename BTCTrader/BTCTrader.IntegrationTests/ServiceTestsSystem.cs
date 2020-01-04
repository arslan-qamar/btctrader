using BTCTrader.Api;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using BTCTrader.Trading.Systems;
using Serilog;
using System.Threading;

namespace BTCTrader.IntegrationTests
{
    public class ServiceTestsSystem : TradingSystem
    {
        public ServiceTestsSystem()
        {
            var jsonFileConfiguration = new JsonFileConfiguration(BTCTrader.Constants.Configuration.FILE_CONFIGURATION);
            AppSettings appSettings = jsonFileConfiguration.GetAppSettings();
            ILogger logger = jsonFileConfiguration.GetLoggerConfiguration().CreateLogger();
            CancellationTokenSource = new CancellationTokenSource();
            ApiClient = new ApiClient(appSettings, logger);
            WSClient = new WSClient(appSettings, CancellationTokenSource.Token, logger);
            base.InitializeServices(ApiClient, WSClient, logger);
        }
    }
}
