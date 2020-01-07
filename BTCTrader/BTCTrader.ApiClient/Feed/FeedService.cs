using BTCTrader.Entities.Feed;
using BTCTrader.Models.Feed.Event;
using BTCTrader.Models.JsonConverters;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BTCTrader.Api.Feed.IFeedService;

namespace BTCTrader.Api.Feed
{
    public class FeedService : IFeedService
    {
        private IWSClient _wsClient;
        private ILogger _logger;
        public FeedService(IWSClient wsClient, ILogger logger)
        {
            _wsClient = wsClient;
            _logger = logger;
        }

        public event TickEventHandler OnTickEventReceived;
        public event TradeEventHandler OnTradeEventReceived;
        public event OrderBookEventHandler OnOrderBookEventReceived;
        public event OrderChangeEventHandler OnOrderChangeEventReceived;
        public event HeartBeatEventHandler OnHeartBeatEventReceived;
        public event ErrorEventHandler OnErrorEventReceived;


        public async Task Subscribe(List<String> channels, List<String> marketIds)
        {
            await _wsClient.Subscribe(channels, marketIds, EventMessageReceived);
        }


        private bool EventMessageReceived(string eventType, string content)
        {
            switch (eventType)
            {
                case EventType.Trade:
                    OnTradeEventReceived?.Invoke(JsonConvert.DeserializeObject<TradeEventModel>(content));
                    break;
                case EventType.Tick:
                    OnTickEventReceived?.Invoke(JsonConvert.DeserializeObject<TickEventModel>(content));
                    break;
                case EventType.OrderChange:
                    OnOrderChangeEventReceived?.Invoke(JsonConvert.DeserializeObject<OrderChangeEventModel>(content));
                    break;
                case EventType.OrderBook:
                    OnOrderBookEventReceived?.Invoke(JsonConvert.DeserializeObject<OrderBookEventModel>(content, new OrderBookEntryConverter()));
                    break;
                case EventType.HeartBeat:
                    OnHeartBeatEventReceived?.Invoke(JsonConvert.DeserializeObject<HeartBeatEventModel>(content));
                    break;
                case EventType.FundChange:
                    break;
                case EventType.Error:
                    OnErrorEventReceived?.Invoke(JsonConvert.DeserializeObject<ErrorEventModel>(content));
                    break;
                default:
                    break;
            }

            return true;
        }

    }
}
