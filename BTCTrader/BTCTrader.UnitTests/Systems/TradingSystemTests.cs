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
        public void InitializeServicesTest()
        {
            TradingSystem tradingSystem = new TradingSystem();
            AppSettings appSettings = FakeAppSettings();

            ApiClient apiClient = new ApiClient(appSettings);
            tradingSystem.InitializeServices(apiClient);

            AllTradeServicesAreInitialized(tradingSystem);
        }

        

        [Fact]
        public void IAppSettingsConfigurationConstructorTest()
        {
            Mock<IAppSettingsConfiguration> mockAppSettingsConfiguration = new Mock<IAppSettingsConfiguration>();
            AppSettings appSettings = FakeAppSettings();
            mockAppSettingsConfiguration.Setup(m => m.GetAppSettings()).Returns(appSettings);

            TradingSystem tradingSystem = new TradingSystem(mockAppSettingsConfiguration.Object);
            ApiClient apiClient = new ApiClient(appSettings);
            tradingSystem.InitializeServices(apiClient);

            AllTradeServicesAreInitialized(tradingSystem);
        }

        
    }
}
