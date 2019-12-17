using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using BTCTrader.IntegrationTests.Base;
using BTCTrader.Models.Account;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Xunit;

namespace BTCTrader.IntegrationTests.Account
{
    public class AccountServiceTests : ServiceTestsBase
    {
        public AccountServiceTests(ServiceTestsFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async void GetAssets()
        {            
            var result = await _fixture.AccountService.GetAssetsAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));

        }

    }
}
