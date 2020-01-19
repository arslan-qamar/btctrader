using BTCTrader.IntegrationTests.Base;
using Xunit;

namespace BTCTrader.IntegrationTests.Account
{
    public class AccountServiceTests : ServiceTestsBase
    {
        public AccountServiceTests(ServiceTestsSystem system) : base(system)
        {
        }

        [Fact]
        public async void GetAssets()
        {
            var result = await System.AccountService.GetAssetsAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));

        }

        [Fact]
        public async void GetTransactions()
        {
            var result = await System.AccountService.GetTransactionsAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));

        }

        [Fact]
        public async void GetTradingFees()
        {
            var result = await System.AccountService.GetTradingFees();
            Assert.NotNull(result);
            result.FeeByMarkets.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));

        }
    }
}
