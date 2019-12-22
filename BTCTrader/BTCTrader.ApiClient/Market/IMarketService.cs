using BTCTrader.Models.Market;
using BTCTrader.Models.Trade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Market
{
    public interface IMarketService
    {
        Task<List<MarketModel>> GetMarketsAsync();
        Task<List<MarketTickerModel>> GetMarketTickersAsync(List<MarketModel> markets);
        Task<List<TradeModel>> GetMarketTradesAsync(MarketModel market, Int64? before = null, Int64? after = null, int limit = 10);
        Task<List<MarketOrderBookModel>> GetMarketOrderBooksAsync(List<MarketModel> market, int level = 1);
        Task<List<MarketCandleModel>> GetMarketCandlesAsync(MarketModel market, DateTimeOffset from, DateTimeOffset to, string timeWindow = "1h", Int64? before = null, Int64? after = null, int limit = 10);
    }
}