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
using BTCTrader.Trading.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BTCTrader
{
    class Program
    {
        IAppSettingsConfiguration appSettingsConfiguration;
        TradingSystem tradingSystem;
        private Dictionary<string, string> cmdArgs;

        public Program(string[] args)
        {
            this.cmdArgs = args.Select(s => new Regex(@"/(?<name>.+?):(?<val>.+)").Match(s)).Where(m => m.Success).ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value);

            appSettingsConfiguration = LoadIAppSettingsConfiguration(this.cmdArgs);
        }

        private IAppSettingsConfiguration LoadIAppSettingsConfiguration(Dictionary<string, string> cmdArgs)
        {
            if(cmdArgs.ContainsKey(Constants.Configuration.CONFIG_FILE))
            {

            }
            return null;
        }

        public static void Main(string[] args)
        {

            Program p = new Program(args);
            p.LoadTradingSystem();
            p.RunMakeMeRich();

            //appSettingsConfiguration = new JsonFileConfiguration(Constants.Configuration.FILE_CONFIGURATION);
            //tradingSystem = new TradingSystem(appSettingsConfiguration);          
            
            //List<OrderModel> orders = await orderService.GetOrdersAsync(OrderState.All);

            //List<TradeModel> trades = await tradeService.GetTradesAsync();

            //List<AssetModel> assets = await accountService.GetAssetsAsync();

            //List<MarketModel> markets = await marketService.GetMarketsAsync();

            //List<MarketTickerModel> marketTickers = await marketService.GetMarketTickersAsync(markets);

        }

        private void LoadTradingSystem()
        {
            
            appSettingsConfiguration = new JsonFileConfiguration(Constants.Configuration.FILE_CONFIGURATION);
            tradingSystem = new TradingSystem(appSettingsConfiguration);
        }


        private void RunMakeMeRich()
        {
            throw new NotImplementedException();
        }

       
    }
}
