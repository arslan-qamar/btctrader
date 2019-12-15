using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace BTCTrader.IntegrationTests.Account
{
    public class AccountServiceFixture
    {
        public AccountService AccountService;
        public ApiClient ApiClient;
        public AccountServiceFixture()
        {
            AppSettings appSettings;
            ConfigurationHelper configurationHelper = new ConfigurationHelper(new ConfigurationBuilder().AddJsonFile("appsettings.json"));
            appSettings = configurationHelper.GetAppSettings();         
            ApiClient = new ApiClient(appSettings);
            AccountService = new AccountService(ApiClient);
        }
    }
}
