using BTCTrader.Entities.Feed;
using BTCTrader.IntegrationTests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BTCTrader.IntegrationTests.Feed
{
    public class FeedServiceTests : ServiceTestsBase
    {
        public FeedServiceTests(ServiceTestsSystem system) : base(system)
        {
        }


        [Fact]
        public async void SubscribeFeedsAndListenForFeedEventsTillAtleaseAnEventTypeIsReceived()
        {

            var markets = await System.MarketService.GetMarketsAsync();
            var eventTypes = new List<string>() { EventType.Tick, EventType.Trade, EventType.OrderBook, EventType.HeartBeat };
            var marketIds = markets.Select(m => m.MarketId).ToList<string>();

            System.WSFeedService.OnHeartBeatEventReceived += WSFeedService_OnHeartBeatEventReceived;
            System.WSFeedService.OnErrorEventReceived += WSFeedService_OnErrorEventReceived;
            System.WSFeedService.OnOrderBookEventReceived += WSFeedService_OnOrderBookEventReceived;
            System.WSFeedService.OnTickEventReceived += WSFeedService_OnTickEventReceived;
            System.WSFeedService.OnTradeEventReceived += WSFeedService_OnTradeEventReceived;
            await System.WSFeedService.Subscribe(eventTypes, marketIds);

        }

        private void WSFeedService_OnTradeEventReceived(Models.Feed.Event.TradeEventModel e)
        {
            this.AllPropertiesAreInitialized(e);
            System.StopTradingSystem();
        }

        private void WSFeedService_OnTickEventReceived(Models.Feed.Event.TickEventModel e)
        {
            this.AllPropertiesAreInitialized(e);
            System.StopTradingSystem();
        }

        private void WSFeedService_OnOrderBookEventReceived(Models.Feed.Event.OrderBookEventModel e)
        {
            this.AllPropertiesAreInitialized(e, new List<string>() { "SnapshotId" });
            System.StopTradingSystem();
        }

        private void WSFeedService_OnErrorEventReceived(Models.Feed.Event.ErrorEventModel e)
        {
            this.AllPropertiesAreInitialized(e);
            throw new Exception($"Exception Code : {e.Code} , Message : {e.Message}");
        }

        private void WSFeedService_OnHeartBeatEventReceived(Models.Feed.Event.HeartBeatEventModel e)
        {
            this.AllPropertiesAreInitialized(e);
            System.StopTradingSystem();
        }
    }
}
