namespace BTCTrader.Entities.Feed
{
    public class MessageType
    {
        class Subscribe : MessageType
        {
            public override string ToString()
            {
                return "subscribe";
            }
        }

        class AddSubscription : MessageType
        {
            public override string ToString()
            {
                return "addSubscription";
            }
        }


        class RemoveSubscription : MessageType
        {
            public override string ToString()
            {
                return "removeSubscription";
            }
        }
    }
}
