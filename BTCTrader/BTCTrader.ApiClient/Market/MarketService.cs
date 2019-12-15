using BTCTrader.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCTrader.Api.Market
{
    public class MarketService : BaseService, IMarketService
    {
        private readonly ApiClient _apiClient;

        public MarketService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task<List<MarketModel>> GetMarketsAsync()
        {
            var result = await _apiClient.Get($"{VERSION}markets", null);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MarketModel>>(result.Content);
        }

        public async Task<List<MarketTickerModel>> GetMarketTickersAsync(List<MarketModel> markets)
        {
            if (markets.Count == 0)
            {
                throw new ArgumentException(nameof(GetMarketTickersAsync) + "requires atleast one market to fetch its ticker information", nameof(markets));
            }

            var result = await _apiClient.Get($"{VERSION}markets/tickers",
                string.Join("&", markets?.Select(m => "marketId=" + m.MarketId)));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MarketTickerModel>>(result.Content);
        }


    }
}
