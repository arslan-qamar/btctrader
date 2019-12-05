using BTCTrader.Api;
using BTCTrader.Api.Account;
using BTCTrader.Api.Orders;
using BTCTrader.Configuration;
using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;

namespace BTCTrader
{
    class Program
    {
        private const string BaseUrl = "https://api.btcmarkets.net";
        private const string ApiKey = "e24c4f0c-d351-4c1c-8183-824e7cb6d3fb";
        private const string PrivateKey = "zxxdPnWDrYcz2dj9MmPp6j5S/wj0/tXT2TVWzoTZaWYUNbOFgNjlriVGzsHBzYgCwhkPkLuvqexYJw5iv5rvrQ==";

         
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            AppSettings appSettings;
            ConfigurationHelper configurationHelper = new ConfigurationHelper(new ConfigurationBuilder().AddJsonFile("appsettings.json"));
            appSettings = configurationHelper.GetAppSettings();

            var orderService = new OrderService(new ApiClient(appSettings));
            var accountService  = new AccountService(new ApiClient(appSettings));

            await orderService.GetOrdersAsync();

            var assets = await accountService.GetAssetsAsync();
           
            
        }
    }
}
