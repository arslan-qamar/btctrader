using BTCTrader.IntegrationTests.Base;
using System;
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


        [Fact]
        public async void GetMarketTradesAsync()
        {
            var markets = await System.MarketService.GetMarketsAsync();
            var result = await System.MarketService.GetMarketTradesAsync(markets[0]);
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m, new System.Collections.Generic.List<string>() { "Fee", "LiquidityType", "OrderId" })));
        }

        [Fact]
        public async void GetMarketOrderBookAsync()
        {
            var markets = await System.MarketService.GetMarketsAsync();
            var result = await System.MarketService.GetMarketOrderBooksAsync(markets);
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }

        [Fact]
        public async void GetMarketCandlesAsync()
        {
            var markets = await System.MarketService.GetMarketsAsync();
            var result = await System.MarketService.GetMarketCandlesAsync(markets[0], DateTimeOffset.Now.AddHours(-4.0), DateTimeOffset.Now);
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }

    }
}


