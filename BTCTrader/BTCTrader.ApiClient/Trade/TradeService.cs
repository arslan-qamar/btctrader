using BTCTrader.Models.Trade;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Trade
{
    public class TradeService : BaseService, ITradeService
    {
        public TradeService(IApiClient apiClient, ILogger logger) : base(apiClient, logger)
        {
        }

        public async Task<List<TradeModel>> GetTradesAsync()
        {
            var result = await _apiClient.Get($"{VERSION}trades", "marketId=XRP-AUD");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<TradeModel>>(result.Content);
        }


    }
}
