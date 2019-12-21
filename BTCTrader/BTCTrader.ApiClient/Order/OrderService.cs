using BTCTrader.Entities.Order;
using BTCTrader.Models.Order;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Order
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApiClient apiClient, ILogger logger) : base(apiClient, logger)
        {
        }

        public async Task<List<OrderModel>> GetOpenOrdersAsync()
        {
            var result = await _apiClient.Get($"{VERSION}orders", "status=open");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task<List<OrderModel>> GetOrdersAsync(string orderState = OrderState.All)
        {
            var result = await _apiClient.Get($"{VERSION}orders", $"status={orderState}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);

            //var hasBefore = result.Headers.TryGetValues("BM_BEFORE", out IEnumerable<string> befores);
            //var hasAfter = result.Headers.TryGetValues("BM-AFTER", out IEnumerable<string> afters);
            //var queryString = $"status=all&limit={limit}";

            //if (hasBefore)
            //    queryString += $"&before={befores.First()}";

            //if (hasAfter)
            //    queryString += $"&after={afters.First()}";

            //result = await _apiClient.Get("/v3/orders", queryString);            
        }

        public async Task<List<OrderModel>> PlaceNewOrder(OrderModel model)
        {
            var result = await _apiClient.Post("/v3/orders", null, model);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task<List<OrderModel>> CancelOrder(string id)
        {
            var result = await _apiClient.Delete($"/v3/orders/{id}", null);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task<List<OrderModel>> CancelAll()
        {
            var result = await _apiClient.Delete($"/v3/orders", "marketId=BTC-AUD");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }
    }
}
