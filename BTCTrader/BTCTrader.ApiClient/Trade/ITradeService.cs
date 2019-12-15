using BTCTrader.Models.Trade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Trade
{
    public interface ITradeService
    {
        Task<List<TradeModel>> GetTradesAsync();
    }
}