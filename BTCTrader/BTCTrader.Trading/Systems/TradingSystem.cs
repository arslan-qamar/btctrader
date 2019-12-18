using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Market;
using BTCTrader.Api.Order;
using BTCTrader.Api.Trade;
using BTCTrader.Configuration;
using Serilog.Core;

namespace BTCTrader.Trading.Systems
{
    public class TradingSystem
    {
        public IAccountService AccountService;
        public IMarketService MarketService;
        public IOrderService OrderService;
        public ITradeService TradeService;
        public Logger Logger;
        protected internal ApiClient ApiClient;

        protected TradingSystem()
        {

        }

        protected void InitializeServices(ApiClient apiClient)
        {
            ApiClient = apiClient;
            AccountService = new AccountService(apiClient);
            MarketService = new MarketService(apiClient);
            OrderService = new OrderService(apiClient);
            TradeService = new TradeService(apiClient);
        }
        
        public TradingSystem(ITradingSystemConfiguration tradingSystemConfiguration)
        {
            ApiClient = new ApiClient(tradingSystemConfiguration.GetAppSettings());
            InitializeServices(ApiClient);

            Logger = tradingSystemConfiguration.GetLoggerConfiguration().CreateLogger();
            
        }
    }
}
