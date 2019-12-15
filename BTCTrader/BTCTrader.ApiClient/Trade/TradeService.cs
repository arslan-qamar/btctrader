using BTCTrader.Models.Trade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Trade
{
    public class TradeService : BaseService, ITradeService
    {
        private readonly ApiClient _apiClient;

        public TradeService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<TradeModel>> GetTradesAsync()
        {
            var result = await _apiClient.Get($"{VERSION}trades", "marketId=XRP-AUD");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<TradeModel>>(result.Content);
        }


    }
}
