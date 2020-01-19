using System;

namespace BTCTrader
{
    class Program
    {
        public static void Main(string[] args)
        {

            TradingBot tradingBot = new TradingBot(args);

            tradingBot.RunMakeMeRich();

            Console.ReadKey();
        }     
    }
}
