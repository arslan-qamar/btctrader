using BTCTrader.Models.Market;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Market
{
    public interface IMarketService
    {
        Task<List<MarketModel>> GetMarketsAsync();
        Task<List<MarketTickerModel>> GetMarketTickersAsync(List<MarketModel> markets);
    }
}