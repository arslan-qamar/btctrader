using BTCTrader.IntegrationTests.Base;
using Xunit;

namespace BTCTrader.IntegrationTests.Trade
{
    public class TradeServiceTests : ServiceTestsBase
    {
        public TradeServiceTests(APIFixture fixture) : base(fixture)
        {
        }


        [Fact]
        public async void GetTradesAsync()
        {
            var result = await _fixture.TradeService.GetTradesAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }
    }
}
