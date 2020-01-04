namespace BTCTrader.Entities.Feed
{
    public static class EventType
    {
        public const string Tick = "tick";
        public const string Trade = "trade";
        public const string OrderBook = "orderbook";
        public const string OrderChange = "orderChange";
        public const string FundChange = "fundChange";
        public const string HeartBeat = "heartbeat";
        public const string Error = "error";
    }
}
