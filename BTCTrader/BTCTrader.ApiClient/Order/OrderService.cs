using BTCTrader.Entities.Order;
using BTCTrader.Models.Market;
using BTCTrader.Models.Order;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCTrader.Api.Order
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IApiClient apiClient, ILogger logger) : base(apiClient, logger)
        {
        }

        public async Task<List<OrderModel>> GetOpenOrdersAsync()
        {
            var result = await _apiClient.Get($"{VERSION}orders", $"status={OrderState.Open}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task<List<OrderModel>> GetOrdersAsync(string marketId, Int64? before, Int64? after, int limit, string orderState)
        {
            var result = await _apiClient.Get($"{VERSION}orders", $"marketId={marketId}&before={before}&after={after}&limit={limit}&status={orderState}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task<OrderModel> PlaceNewOrderAsync(OrderModel model)
        {
            var result = await _apiClient.Post("/v3/orders", null, model);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OrderModel>(result.Content);
        }

        public async Task<OrderModel> CancelOrderAsync(string id)
        {
            var result = await _apiClient.Delete($"/v3/orders/{id}", null);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OrderModel>(result.Content);
        }

        public async Task<List<OrderModel>> CancelAllAsync(List<MarketModel> markets)
        {
            var result = await _apiClient.Delete($"/v3/orders", string.Join("&", markets?.Select(m => "marketId=" + m.MarketId)));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task<OrderModel> GetOrderAsync(string id)
        {
            var result = await _apiClient.Get($"/v3/orders/{id}", null);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OrderModel>(result.Content);
        }


    }
}
