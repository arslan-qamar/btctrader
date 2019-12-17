using BTCTrader.Api;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using BTCTrader.Trading.Systems;

namespace BTCTrader.IntegrationTests
{
    public class ServiceTestsSystem : TradingSystem
    {
        public ServiceTestsSystem()
        {
            AppSettings appSettings;
            appSettings = new JsonFileConfiguration(BTCTrader.Constants.Configuration.FILE_CONFIGURATION).GetAppSettings();
            ApiClient = new ApiClient(appSettings);

            base.InitializeServices(ApiClient);
            
        }
    }
}
