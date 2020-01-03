using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Market;
using BTCTrader.Api.Order;
using BTCTrader.Api.Trade;
using BTCTrader.Api.WebSockect;
using BTCTrader.Configuration;
using Serilog;
using System.Threading;

namespace BTCTrader.Trading.Systems
{
    public class TradingSystem
    {
        public IAccountService AccountService;
        public IMarketService MarketService;
        public IOrderService OrderService;
        public ITradeService TradeService;
        public WebSocketFeedService WSFeedService;

        public ILogger Logger;
        protected internal IApiClient ApiClient;
        protected internal IWSClient WSClient;

        protected TradingSystem()
        {

        }

        protected void InitializeServices(IApiClient apiClient, IWSClient wsClient, ILogger logger)
        {
            ApiClient = apiClient;
            WSClient = wsClient;
            Logger = logger;
            AccountService = new AccountService(apiClient, Logger);
            MarketService = new MarketService(apiClient, Logger);
            OrderService = new OrderService(apiClient, Logger);
            TradeService = new TradeService(apiClient, Logger);
            WSFeedService = new WebSocketFeedService(wsClient, Logger);
        }

        public TradingSystem(ITradingSystemConfiguration tradingSystemConfiguration, CancellationTokenSource cancellationTokenSource)
        {
            Logger = tradingSystemConfiguration.GetLoggerConfiguration().CreateLogger();
            ApiClient = new ApiClient(tradingSystemConfiguration.GetAppSettings(), Logger);
            WSClient = new WSClient(tradingSystemConfiguration.GetAppSettings(), cancellationTokenSource.Token, Logger);
            InitializeServices(ApiClient, WSClient, Logger);
        }
    }
}
