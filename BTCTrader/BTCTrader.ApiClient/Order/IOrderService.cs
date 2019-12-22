using BTCTrader.Entities.Order;
using BTCTrader.Models.Market;
using BTCTrader.Models.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Order
{
    public interface IOrderService
    {
        Task<List<OrderModel>> CancelAllAsync(List<MarketModel> markets = null);
        Task<OrderModel> CancelOrderAsync(string id);
        Task<OrderModel> GetOrderAsync(string id);
        Task<List<OrderModel>> GetOpenOrdersAsync();
        Task<List<OrderModel>> GetOrdersAsync(string marketId = null, Int64? before = null, Int64? after = null, int limit = 10, string orderState = OrderState.All);
        Task<OrderModel> PlaceNewOrderAsync(OrderModel model);
    }
}