using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Xunit;

namespace BTCTrader.IntegrationTests.Account
{
    public class AccountServiceTests : IClassFixture<AccountServiceFixture>
    {
        AccountServiceFixture _fixture;
        public AccountServiceTests(AccountServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void GetAssets()
        {            
            var result = await _fixture.AccountService.GetAssetsAsync();
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetAssets2()
        {
            var result = await _fixture.AccountService.GetAssetsAsync();
            Assert.NotNull(result);
        }
    }
}
