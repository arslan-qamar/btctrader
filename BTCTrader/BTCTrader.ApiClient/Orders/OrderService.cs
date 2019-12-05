using BTCTrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCTrader.Api.Orders
{
    public class OrderService : BaseService
    {
        private readonly ApiClient _apiClient;

        public OrderService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<OrderModel>> GetOpenOrdersAsync()
        {
            var result = await _apiClient.Get($"{VERSION}orders", "status=open");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task<List<OrderModel>> GetOrdersAsync()
        {
            var result = await _apiClient.Get($"{VERSION}orders", "status=all");            
            var hasBefore = result.Headers.TryGetValues("BM_BEFORE", out IEnumerable<string> befores);
            var hasAfter = result.Headers.TryGetValues("BM-AFTER", out IEnumerable<string> afters);
            var queryString = "status=all&limit=5";

            if (hasBefore)
                queryString += $"&before={befores.First()}";

            if (hasAfter)
                queryString += $"&after={afters.First()}";

            result = await _apiClient.Get("/v3/orders", queryString);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderModel>>(result.Content);
        }

        public async Task PlaceNewOrder(OrderModel model)
        {
            var result = await _apiClient.Post("/v3/orders", null, model);
            Console.WriteLine(result);
        }

        public async Task CancelOrder(string id)
        {
            var result = await _apiClient.Delete($"/v3/orders/{id}", null);
            Console.WriteLine(result);
        }

        public async Task CancelAll()
        {
            var result = await _apiClient.Delete($"/v3/orders", "marketId=BTC-AUD");
            Console.WriteLine(result);
        }
    }
}
