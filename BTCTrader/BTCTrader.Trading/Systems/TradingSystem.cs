using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Market;
using BTCTrader.Api.Order;
using BTCTrader.Api.Trade;
using BTCTrader.Configuration;
using BTCTrader.Entities;

namespace BTCTrader.Trading.Systems
{
    public class TradingSystem
    {
        public IAccountService AccountService;
        public IMarketService MarketService;
        public IOrderService OrderService;
        public ITradeService TradeService;
        protected internal ApiClient ApiClient;

        public TradingSystem()
        {

        }

        public void InitializeServices(ApiClient apiClient)
        {
            ApiClient = apiClient;
            AccountService = new AccountService(apiClient);
            MarketService = new MarketService(apiClient);
            OrderService = new OrderService(apiClient);
            TradeService = new TradeService(apiClient);
        }
        
        public TradingSystem(IAppSettingsConfiguration appSettingsConfiguration)
        {
            AppSettings appSettings;

            appSettings = appSettingsConfiguration.GetAppSettings();
            ApiClient = new ApiClient(appSettings);

            InitializeServices(ApiClient);

        }
    }
}
