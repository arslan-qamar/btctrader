using BTCTrader.Api;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using BTCTrader.Trading.Systems;
using Moq;
using Xunit;

namespace BTCTrader.UnitTests.Systems
{
    public class TradingSystemTests : UnitTestsBaseClass
    {       

        [Fact]
        public void IAppSettingsConfigurationConstructorTest()
        {
            Mock<IAppSettingsConfiguration> mockAppSettingsConfiguration = new Mock<IAppSettingsConfiguration>();
            AppSettings appSettings = FakeAppSettings();
            mockAppSettingsConfiguration.Setup(m => m.GetAppSettings()).Returns(appSettings);

            TradingSystem tradingSystem = new TradingSystem(mockAppSettingsConfiguration.Object);           

            AllTradeServicesAreInitialized(tradingSystem);
        }

        
    }
}
