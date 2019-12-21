using BTCTrader.Models.JsonConverters;
using BTCTrader.Models.Market;
using BTCTrader.Models.Trade;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCTrader.Api.Market
{
    public class MarketService : BaseService, IMarketService
    {
        public MarketService(ApiClient apiClient, ILogger logger) : base(apiClient, logger)
        {
        }

        public async Task<List<MarketModel>> GetMarketsAsync()
        {
            var results = await _apiClient.Get($"{VERSION}markets", null);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MarketModel>>(results.Content);
        }

        public async Task<List<MarketTickerModel>> GetMarketTickersAsync(List<MarketModel> markets)
        {
            if (markets?.Count == 0)
            {
                throw new ArgumentException(nameof(GetMarketTickersAsync) + "requires atleast one market to fetch its ticker information", nameof(markets));
            }

            var results = await _apiClient.Get($"{VERSION}markets/tickers",
                string.Join("&", markets?.Select(m => "marketId=" + m.MarketId)));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MarketTickerModel>>(results.Content);
        }

        public async Task<List<TradeModel>> GetMarketTradesAsync(MarketModel market, int? before, int? after, int limit)
        {
            if (market == null)
            {
                var exception = new ArgumentException(nameof(GetMarketTradesAsync) + " requires atleast one market to fetch its trades information", nameof(market));
                _logger.Error(exception, "{MethodName} requires atleast one market to fetch its trades information", nameof(GetMarketTradesAsync));
                throw exception;
            }

            var results = await _apiClient.Get($"{VERSION}markets/{market.MarketId}/trades", $"before={before}&after={after}&limit={limit}");

            var trades = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TradeModel>>(results.Content);
            trades.ForEach(t => t.MarketId = market.MarketId);
            return trades;
        }

        public async Task<MarketOrderBookModel> GetMarketOrderBookAsync(MarketModel market, int level)
        {
            if (market == null)
            {
                var exception = new ArgumentException(nameof(GetMarketOrderBookAsync) + " requires atleast one market to fetch market order book information", nameof(market));
                _logger.Error(exception, "{MethodName} requires atleast one market to fetch market order book information", nameof(GetMarketOrderBookAsync));
                throw exception;
            }

            var results = await _apiClient.Get($"{VERSION}markets/{market.MarketId}/orderbook", $"level={level}");

            return Newtonsoft.Json.JsonConvert.DeserializeObject<MarketOrderBookModel>(results.Content, new AskOrBidConverter());            
        }

        public async Task<MarketOrderBookModel> GetMarketCandlesAsync(MarketModel market, string timeWindow, string from, string to, int? before, int? after, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
