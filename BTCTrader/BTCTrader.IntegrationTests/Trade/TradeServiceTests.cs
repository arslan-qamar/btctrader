using BTCTrader.IntegrationTests.Base;
using System;
using System.Collections.Generic;
using Xunit;

namespace BTCTrader.IntegrationTests.Trade
{
    public class TradeServiceTests : ServiceTestsBase
    {
        List<String> optionalFields = new List<String>() { "LiquidityType" };
        public TradeServiceTests(ServiceTestsSystem system) : base(system)
        {
        }


        [Fact]
        public async void GetTradesAsync()
        {
            var result = await System.TradeService.GetTradesAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m,optionalFields)));
        }
    }
}
