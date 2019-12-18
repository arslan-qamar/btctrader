using BTCTrader.Configuration;
using BTCTrader.Entities;
using BTCTrader.Trading.Systems;
using Moq;
using Serilog;
using Xunit;

namespace BTCTrader.UnitTests.Systems
{
    public class TradingSystemTests : UnitTestsBaseClass
    {       

        [Fact]
        public void IAppSettingsConfigurationConstructorTest()
        {
            Mock<ITradingSystemConfiguration> mockTradingSystemConfiguration = new Mock<ITradingSystemConfiguration>();
            AppSettings appSettings = FakeAppSettings();
            mockTradingSystemConfiguration.Setup(m => m.GetAppSettings()).Returns(appSettings);
            mockTradingSystemConfiguration.Setup(m => m.GetLoggerConfiguration()).Returns(new Mock<LoggerConfiguration>().Object);

            TradingSystem tradingSystem = new TradingSystem(mockTradingSystemConfiguration.Object);           

            AllTradeServicesAreInitialized(tradingSystem);
        }

        
    }
}
