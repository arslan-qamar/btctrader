using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Market;
using BTCTrader.Api.Order;
using BTCTrader.Api.Trade;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace BTCTrader.IntegrationTests
{
    public class ServiceTestsFixture
    {
        public IAccountService AccountService;
        public IMarketService MarketService;
        public IOrderService OrderService;
        public ITradeService TradeService;

        public ApiClient ApiClient;
        public ServiceTestsFixture()
        {
            AppSettings appSettings;
            JsonFileConfiguration configuration = new JsonFileConfiguration(Constants.Configuration.FILE_CONFIGURATION);
            appSettings = configuration.GetAppSettings();         
            ApiClient = new ApiClient(appSettings);

            AccountService = new AccountService(ApiClient);
            MarketService = new MarketService(ApiClient);
            OrderService = new OrderService(ApiClient);
            TradeService = new TradeService(ApiClient);
        }
    }
}
