using BTCTrader.Models.Feed.Event;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Feed
{
    public interface IFeedService
    {
        public event TickEventHandler OnTickEventReceived;
        public delegate void TickEventHandler(TickEventModel e);

        public event TradeEventHandler OnTradeEventReceived;
        public delegate void TradeEventHandler(TradeEventModel e);

        public event OrderBookEventHandler OnOrderBookEventReceived;
        public delegate void OrderBookEventHandler(OrderBookEventModel e);

        public event OrderChangeEventHandler OnOrderChangeEventReceived;
        public delegate void OrderChangeEventHandler(OrderChangeEventModel e);

        public event HeartBeatEventHandler OnHeartBeatEventReceived;
        public delegate void HeartBeatEventHandler(HeartBeatEventModel e);

        public event ErrorEventHandler OnErrorEventReceived;
        public delegate void ErrorEventHandler(ErrorEventModel e);

        Task Subscribe(List<string> channels, List<string> marketIds);
    }
}