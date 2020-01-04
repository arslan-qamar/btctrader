using BTCTrader.Entities;
using BTCTrader.Trading.Systems;
using System.Collections.Generic;
using Xunit;

namespace BTCTrader.UnitTests
{
    public class UnitTestsBaseClass
    {
        public AppSettings FakeAppSettings()
        {
            AppSettings appSettings = new AppSettings();
            appSettings.ApiKey = "https://api.btcmarkets.net";
            appSettings.BaseUrl = "Fake Url";
            appSettings.PrivateKey = "Fake Private Key";
            appSettings.WssBaseUrl = "wss://socket.btcmarkets.net/v2";
            appSettings.WssBufferSize = 1024;
            return appSettings;
        }

        protected bool AllFieldsAreInitialized(object model, List<string> optionalFields = null)
        {
            optionalFields = optionalFields == null ? new List<string>() : optionalFields;

            var props = model.GetType().GetFields();

            foreach (var prop in props)
            {
                var val = prop.GetValue(model);
                Assert.True(optionalFields.Contains(prop.Name) || val != null, $"Model : {model.GetType().Name} Field {prop.Name} has value: {val} . It should not be null.");
            }
            return true;
        }

        public void AssertTradingSystemIsFullyInitialized(TradingSystem tradingSystem)
        {
            Assert.NotNull(tradingSystem.AccountService);
            Assert.NotNull(tradingSystem.MarketService);
            Assert.NotNull(tradingSystem.OrderService);
            Assert.NotNull(tradingSystem.TradeService);

        }
    }
}
