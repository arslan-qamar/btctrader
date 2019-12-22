using BTCTrader.Configuration;
using BTCTrader.Trading.Systems;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BTCTrader
{
    class Program
    {
        ITradingSystemConfiguration tradingSystemConfiguration;
        TradingSystem tradingSystem;
        private Dictionary<string, string> cmdArgs;

        public Program(string[] args)
        {
            this.cmdArgs = args.Select(s => new Regex(@"/(?<name>.+?):(?<val>.+)").Match(s)).Where(m => m.Success).ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value);

            tradingSystemConfiguration = LoadITradingSystemConfiguration(this.cmdArgs);

            tradingSystem = new TradingSystem(tradingSystemConfiguration);

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



        }


        private void RunMakeMeRich()
        {

            var x = tradingSystem.AccountService.GetTransactionsAsync().Result;

        }


    }
}
