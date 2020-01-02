using System.Threading.Tasks;

namespace BTCTrader.Api.WebSockect
{
    public interface IWebSocketFeedService
    {

        public Task<bool> StartServiceFeed();
    }
}
