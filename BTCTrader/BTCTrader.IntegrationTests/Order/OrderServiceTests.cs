using BTCTrader.Entities.Order;
using BTCTrader.IntegrationTests.Base;
using BTCTrader.Models.Order;
using System;
using System.Collections.Generic;
using Xunit;

namespace BTCTrader.IntegrationTests.Order
{
    public class OrderServiceTests : ServiceTestsBase
    {
        List<String> optionalFields = new List<String>() { "ClientOrderId", "TriggerPrice", "TargetAmount", "TimeInForce", "PostOnly", "SelfTrade" };
        public OrderServiceTests(ServiceTestsSystem system) : base(system)
        {
        }


        [Fact]
        public async void CancelAllAsync()
        {
            var markets = await System.MarketService.GetMarketsAsync();
            var result = await System.OrderService.CancelAllAsync(markets);
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }

        [Fact]
        public async void GetOpenOrdersAsync()
        {
            var result = await System.OrderService.GetOpenOrdersAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }

        [Fact]
        public async void GetOrdersAsync()
        {
            var result = await System.OrderService.GetOrdersAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m,optionalFields)));
        }

        [Fact]
        public async void PlaceNewOrderThenGetAndCancelAsync()
        {
            OrderModel newOrder = new OrderModel();
            newOrder.MarketId = "BTC-AUD";
            newOrder.Type = OrderType.Limit;
            newOrder.Price = 0.01m;
            newOrder.Amount = 0.0001m;
            newOrder.Side = OrderSide.Bid;
            
            //Place New Order
            var acceptedOrder = await System.OrderService.PlaceNewOrderAsync(newOrder);            
            Assert.NotNull(acceptedOrder);
            Assert.Equal(acceptedOrder.Status, OrderStatus.Accepted);
            Assert.True(this.AllPropertiesAreInitialized(acceptedOrder, optionalFields));

            //Get Order
            var placedOrder = await System.OrderService.GetOrderAsync(acceptedOrder.OrderId);
            Assert.NotNull(placedOrder);
            Assert.Equal(placedOrder.Status, OrderStatus.Placed);
            Assert.Equal(placedOrder.OrderId, acceptedOrder.OrderId);
            Assert.True(this.AllPropertiesAreInitialized(placedOrder, optionalFields));

            //Delete Order
            var deletedOrder = await System.OrderService.CancelOrderAsync(placedOrder.OrderId);
            deletedOrder = await System.OrderService.GetOrderAsync(placedOrder.OrderId);
            Assert.NotNull(deletedOrder);
            Assert.Equal(deletedOrder.Status, OrderStatus.Cancelled);

        }

    }
}
