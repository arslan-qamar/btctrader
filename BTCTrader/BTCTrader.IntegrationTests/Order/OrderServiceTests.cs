using BTCTrader.Entities.Order;
using BTCTrader.IntegrationTests.Base;
using System;
using System.Collections.Generic;
using Xunit;

namespace BTCTrader.IntegrationTests.Order
{
    public class OrderServiceTests : ServiceTestsBase
    {
        List<String> optionalFields = new List<String>() { "ClientOrderId", "TriggerPrice", "TargetAmount", "TimeInForce", "PostOnly", "SelfTrade" };
        public OrderServiceTests(ServiceTestsFixture fixture) : base(fixture)
        {
        }


        [Fact]
        public async void CancelAll()
        {
            var result = await _fixture.OrderService.CancelAll();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }

        [Fact]
        public async void GetOpenOrdersAsync()
        {
            var result = await _fixture.OrderService.GetOpenOrdersAsync();
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m)));
        }

        [Fact]
        public async void GetOrdersAsync()
        {
            var result = await _fixture.OrderService.GetOrdersAsync(orderState:OrderState.All);
            Assert.NotNull(result);
            result.ForEach(m => Assert.True(this.AllPropertiesAreInitialized(m,optionalFields)));
        }

        //[Fact]
        //public async void CancelOrder()
        //{
        //    var result = await _fixture.OrderService.CancelAll();
        //    Assert.NotNull(result);

        //    if (result.Count > 0)
        //    {
        //        OrderModel m = result[0];
        //        Assert.True(this.AllPropertiesAreInitialized(m));
        //    }
        //}

        //[Fact]
        //public async void PlaceNewOrder()
        //{
        //    var result = await _fixture.OrderService.CancelAll();
        //    Assert.NotNull(result);

        //    if (result.Count > 0)
        //    {
        //        OrderModel m = result[0];
        //        Assert.True(this.AllPropertiesAreInitialized(m));
        //    }
        //}        

    }
}
