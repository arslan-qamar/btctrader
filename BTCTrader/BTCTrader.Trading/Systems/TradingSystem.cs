using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Feed;
using BTCTrader.Api.Market;
using BTCTrader.Api.Order;
using BTCTrader.Api.Trade;
using BTCTrader.Configuration;
using Serilog;
using System;
using System.Threading;

namespace BTCTrader.Trading.Systems
{
    public class TradingSystem
    {
        public IAccountService AccountService;
        public IMarketService MarketService;
        public IOrderService OrderService;
        public ITradeService TradeService;
        public IFeedService WSFeedService;
        public ILogger Logger;

        protected internal IApiClient ApiClient;
        protected internal IWSClient WSClient;
        protected internal CancellationTokenSource CancellationTokenSource;
        protected internal TradingSystem()
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
            WSFeedService = new FeedService(wsClient, Logger);
        }

        public TradingSystem(ITradingSystemConfiguration tradingSystemConfiguration, CancellationTokenSource cancellationTokenSource)
        {
            Logger = tradingSystemConfiguration.GetLoggerConfiguration().CreateLogger();
            CancellationTokenSource = cancellationTokenSource;
            ApiClient = new ApiClient(tradingSystemConfiguration.GetAppSettings(), Logger);
            WSClient = new WSClient(tradingSystemConfiguration.GetAppSettings(), cancellationTokenSource.Token, Logger);
            InitializeServices(ApiClient, WSClient, Logger);
        }


        public bool StopTradingSystem(TimeSpan afterDuration = new TimeSpan())
        {
            CancellationTokenSource.CancelAfter(afterDuration);
            return CancellationTokenSource.IsCancellationRequested;
        }
    }
}
