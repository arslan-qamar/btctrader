using BTCTrader.Entities.Feed;
using BTCTrader.Models.Feed.Event;
using BTCTrader.Models.JsonConverters;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;

namespace BTCTrader.Api.WebSockect
{
    public class WebSocketFeedService : IWebSocketFeedService
    {
        private IWSClient _wsClient;
        private ILogger _logger;

        public event TickEventHandler OnTickEventReceived;
        public delegate void TickEventHandler(TickEventModel e);


        public event TradeEventHandler OnTradeEventReceived;
        public delegate void TradeEventHandler(TradeEventModel e);

        public event OrderBookEventHandler OnOrderBookEventReceived;
        public delegate void OrderBookEventHandler(OrderBookEventModel e);

        public event HeartBeatEventHandler OnHeartBeatEventReceived;
        public delegate void HeartBeatEventHandler(HeartBeatEventModel e);

        public event ErrorEventHandler OnErrorEventReceived;
        public delegate void ErrorEventHandler(ErrorEventModel e);

        public WebSocketFeedService(IWSClient wsClient, ILogger logger) 
        {
            _wsClient = wsClient;
            _logger = logger;
        }

        public void Subscribe(List<String> channels, List<String> marketIds)
        {
            _wsClient.Subscribe(channels, marketIds, EventMessageReceived);
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
