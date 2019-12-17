using BTCTrader.IntegrationTests.Base;
using BTCTrader.Models.Market;
using Xunit;

namespace BTCTrader.IntegrationTests.Market
{
    public class MarketServiceTests : ServiceTestsBase
    {
        public MarketServiceTests(ServiceTestsSystem system) : base(system)
        {
        }

        [Fact]
        public async void GetMarketsAsync()
        {
            var result = await System.MarketService.GetMarketsAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
            
        }

        [Fact]
        public async void GetMarketTickersAsync()
        {
            var result = await System.MarketService.GetMarketTickersAsync(await System.MarketService.GetMarketsAsync());
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }
       
    }
}


