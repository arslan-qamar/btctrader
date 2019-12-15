using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Market;
using BTCTrader.Api.Order;
using BTCTrader.Api.Trade;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using BTCTrader.Entities.Order;
using BTCTrader.Models.Account;
using BTCTrader.Models.Market;
using BTCTrader.Models.Order;
using BTCTrader.Models.Trade;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;

namespace BTCTrader
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            AppSettings appSettings;
            ConfigurationHelper configurationHelper = new ConfigurationHelper(new ConfigurationBuilder().AddJsonFile("appsettings.json"));
            appSettings = configurationHelper.GetAppSettings();

          

            var orderService = new OrderService(new ApiClient(appSettings));
            var accountService  = new AccountService(new ApiClient(appSettings));
            var tradeService = new TradeService(new ApiClient(appSettings));
            var marketService = new MarketService(new ApiClient(appSettings));


            List<OrderModel> orders = await orderService.GetOrdersAsync(OrdersState.All);

            List<TradeModel> trades = await tradeService.GetTradesAsync();

            List<AssetModel> assets = await accountService.GetAssetsAsync();

            List<MarketModel> markets = await marketService.GetMarketsAsync();

            List<MarketTickerModel> marketTickers = await marketService.GetMarketTickersAsync(markets);



        }
    }
}
