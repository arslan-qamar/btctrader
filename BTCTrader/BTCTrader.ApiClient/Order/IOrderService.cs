using BTCTrader.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Order
{
    public interface IOrderService
    {
        Task<List<OrderModel>> CancelAll();
        Task<List<OrderModel>> CancelOrder(string id);
        Task<List<OrderModel>> GetOpenOrdersAsync();
        Task<List<OrderModel>> GetOrdersAsync(string orderState = "all");
        Task<List<OrderModel>> PlaceNewOrder(OrderModel model);
    }
}