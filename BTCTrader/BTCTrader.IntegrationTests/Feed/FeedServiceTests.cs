using BTCTrader.Entities.Feed;
using BTCTrader.IntegrationTests.Base;
using BTCTrader.IntegrationTests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BTCTrader.IntegrationTests.Feed
{
    [CollectionDefinition(TestConstants.OrderTestsCollection, DisableParallelization = false)]
    public class FeedServiceTests : ServiceTestsBase, IDisposable
    {
        bool _orderChangeEventReceieved = false;
        bool _eventReceieved = false;
        public FeedServiceTests(ServiceTestsSystem system) : base(system)
        {
            var markets = System.MarketService.GetMarketsAsync().Result;
            var eventTypes = new List<string>() { EventType.Tick, EventType.Trade, EventType.OrderBook, EventType.OrderChange, EventType.HeartBeat };
            var marketIds = markets.Select(m => m.MarketId).ToList<string>();

            System.WSFeedService.OnHeartBeatEventReceived += WSFeedService_OnHeartBeatEventReceived;
            System.WSFeedService.OnErrorEventReceived += WSFeedService_OnErrorEventReceived;
            System.WSFeedService.OnOrderBookEventReceived += WSFeedService_OnOrderBookEventReceived;
            System.WSFeedService.OnTickEventReceived += WSFeedService_OnTickEventReceived;
            System.WSFeedService.OnTradeEventReceived += WSFeedService_OnTradeEventReceived;
            System.WSFeedService.OnOrderChangeEventReceived += WSFeedService_OnOrderChangeEventReceived;
            System.WSFeedService.Subscribe(eventTypes, marketIds);
        }

        [Fact]
        public void ReceiveAtleaseOneEvent()
        {
            SpinWait.SpinUntil(() => _eventReceieved == false, TimeSpan.FromSeconds(5.0));
        }

        [Fact]
        public async void SubscribeOrderChangeFeedAndReceiveOrderChangeEvent()
        {
            var markets = await System.MarketService.GetMarketsAsync();
            var eventTypes = new List<string>() { EventType.OrderChange };
            var marketIds = markets.Select(m => m.MarketId).ToList<string>();

            OrderServiceTests orderServiceTests = new OrderServiceTests(System);
            System.WSFeedService.OnOrderChangeEventReceived += WSFeedService_OnOrderChangeEventReceived;
            Task subscriber = System.WSFeedService.Subscribe(eventTypes, marketIds);

            orderServiceTests.PlaceNewOrderThenGetAndCancelAsync();

            SpinWait.SpinUntil(() => !_orderChangeEventReceieved, TimeSpan.FromSeconds(5.0));
        }

        private void WSFeedService_OnOrderChangeEventReceived(Models.Feed.Event.OrderChangeEventModel e)
        {
            ValidateEventReceived(e, new List<string> {
                nameof(Models.Feed.Event.OrderChangeEventModel.TriggerStatus),
                nameof(Models.Feed.Event.OrderChangeEventModel.TriggerPrice),
                nameof(Models.Feed.Event.OrderChangeEventModel.TargetAmount),
                nameof(Models.Feed.Event.OrderChangeEventModel.TimeInForce),
                nameof(Models.Feed.Event.OrderChangeEventModel.PostOnly),
                nameof(Models.Feed.Event.OrderChangeEventModel.SelfTrade),
                nameof(Models.Feed.Event.OrderChangeEventModel.ClientOrderId),
                nameof(Models.Feed.Event.OrderChangeEventModel.OpenAmount),
            });
            _orderChangeEventReceieved = true;
        }

        private void WSFeedService_OnTradeEventReceived(Models.Feed.Event.TradeEventModel e)
        {
            ValidateEventReceived(e);
        }

        private void ValidateEventReceived(object e, List<string> optionalFields = null)
        {
            this.AllPropertiesAreInitialized(e, optionalFields);
            _eventReceieved = true;
        }

        private void WSFeedService_OnTickEventReceived(Models.Feed.Event.TickEventModel e)
        {
            ValidateEventReceived(e);
        }

        private void WSFeedService_OnOrderBookEventReceived(Models.Feed.Event.OrderBookEventModel e)
        {
            ValidateEventReceived(e, new List<string>() { nameof(Models.Feed.Event.OrderBookEventModel.SnapshotId) });
        }

        private void WSFeedService_OnErrorEventReceived(Models.Feed.Event.ErrorEventModel e)
        {
            this.AllPropertiesAreInitialized(e);
            throw new Exception($"Exception Code : {e.Code} , Message : {e.Message}");
        }

        private void WSFeedService_OnHeartBeatEventReceived(Models.Feed.Event.HeartBeatEventModel e)
        {
            ValidateEventReceived(e);
        }

        public void Dispose()
        {
            System.StopTradingSystem();
        }
    }
}
