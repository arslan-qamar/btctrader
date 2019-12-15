using BTCTrader.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Order
{
    public interface IOrderService
    {
        Task CancelAll();
        Task CancelOrder(string id);
        Task<List<OrderModel>> GetOpenOrdersAsync();
        Task<List<OrderModel>> GetOrdersAsync(string orderState = "all");
        Task PlaceNewOrder(OrderModel model);
    }
}