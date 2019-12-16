using BTCTrader.IntegrationTests.Base;
using BTCTrader.Models.Market;
using Xunit;

namespace BTCTrader.IntegrationTests.Market
{
    public class MarketServiceTests : ServiceTestsBase
    {
        public MarketServiceTests(APIFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async void GetMarketsAsync()
        {
            var result = await _fixture.MarketService.GetMarketsAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
            
        }

        [Fact]
        public async void GetMarketTickersAsync()
        {
            var result = await _fixture.MarketService.GetMarketTickersAsync(await _fixture.MarketService.GetMarketsAsync());
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }
       
    }
}


