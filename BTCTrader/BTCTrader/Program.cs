using BTCTrader.Configuration;
using BTCTrader.Entities.Feed;
using BTCTrader.Trading.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace BTCTrader
{
    class Program
    {
        ITradingSystemConfiguration tradingSystemConfiguration;
        TradingSystem tradingSystem;
        CancellationTokenSource  cancellationTokenSource;
        private Dictionary<string, string> cmdArgs;

        public Program(string[] args)
        {
            this.cmdArgs = args.Select(s => new Regex(@"/(?<name>.+?):(?<val>.+)").Match(s)).Where(m => m.Success).ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value);

            cancellationTokenSource = new CancellationTokenSource();

            tradingSystemConfiguration = LoadITradingSystemConfiguration(this.cmdArgs);

            tradingSystem = new TradingSystem(tradingSystemConfiguration, cancellationTokenSource);

            tradingSystem.Logger.ForContext<Program>().Verbose("Trading System Initialized Successfully");

            tradingSystem.Logger.ForContext<Program>().Warning("Trade Responsibily");

        }

        private ITradingSystemConfiguration LoadITradingSystemConfiguration(Dictionary<string, string> cmdArgs)
        {
            if (cmdArgs.ContainsKey(Constants.Configuration.CONFIG_FILE))
            {
                return new JsonFileConfiguration(cmdArgs[Constants.Configuration.CONFIG_FILE]);
            }

            return new JsonFileConfiguration();
        }

        public static void Main(string[] args)
        {

            Program p = new Program(args);


            p.RunMakeMeRich();

            Console.ReadKey();


        }


        private async void RunMakeMeRich()
        {

            var markets = await tradingSystem.MarketService.GetMarketsAsync();

            tradingSystem.WSFeedService.Subscribe(new List<string>() {Channels.Tick, Channels.Trade}, new List<string>() { markets[0].MarketId });
            
        }


    }
}
