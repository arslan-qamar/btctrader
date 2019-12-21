using BTCTrader.Models.Market;
using BTCTrader.Models.Trade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Market
{
    public interface IMarketService
    {
        Task<List<MarketModel>> GetMarketsAsync();
        Task<List<MarketTickerModel>> GetMarketTickersAsync(List<MarketModel> markets);
        Task<List<TradeModel>> GetMarketTradesAsync(MarketModel market, int? before = null, int? after = null, int limit = 10);
        Task<MarketOrderBookModel> GetMarketOrderBookAsync(MarketModel market, int level = 1);
        Task<MarketOrderBookModel> GetMarketCandlesAsync(MarketModel market, string timeWindow = "1h",  string from = null,string to = null, int? before = null, int? after = null, int limit = 10);
    }
}