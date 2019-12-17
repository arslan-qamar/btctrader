using BTCTrader.Entities;
using BTCTrader.Trading.Systems;
using Xunit;

namespace BTCTrader.UnitTests
{
    public class UnitTestsBaseClass
    {
        public AppSettings FakeAppSettings()
        {
            AppSettings appSettings = new AppSettings();
            appSettings.ApiKey = "Fake Key";
            appSettings.BaseUrl = "Fake Url";
            appSettings.PrivateKey = "Fake Private Key";
            return appSettings;
        }

        public void AllTradeServicesAreInitialized(TradingSystem tradingSystem)
        {
            Assert.NotNull(tradingSystem.AccountService);
            Assert.NotNull(tradingSystem.MarketService);
            Assert.NotNull(tradingSystem.OrderService);
            Assert.NotNull(tradingSystem.TradeService);
        }
    }
}
