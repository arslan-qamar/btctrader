using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Market;
using BTCTrader.Api.Order;
using BTCTrader.Api.Trade;
using BTCTrader.Configuration;
using Serilog;

namespace BTCTrader.Trading.Systems
{
    public class TradingSystem
    {
        public IAccountService AccountService;
        public IMarketService MarketService;
        public IOrderService OrderService;
        public ITradeService TradeService;
        public ILogger Logger;
        protected internal ApiClient ApiClient;

        protected TradingSystem()
        {

        }

        protected void InitializeServices(ApiClient apiClient, ILogger logger)
        {
            ApiClient = apiClient;
            Logger = logger;
            AccountService = new AccountService(apiClient, Logger);
            MarketService = new MarketService(apiClient, Logger);
            OrderService = new OrderService(apiClient, Logger);
            TradeService = new TradeService(apiClient, Logger);
        }

        public TradingSystem(ITradingSystemConfiguration tradingSystemConfiguration)
        {
            Logger = tradingSystemConfiguration.GetLoggerConfiguration().CreateLogger();
            ApiClient = new ApiClient(tradingSystemConfiguration.GetAppSettings(), Logger);
            InitializeServices(ApiClient, Logger);
        }
    }
}
