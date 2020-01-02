using Serilog;
using System.Threading.Tasks;

namespace BTCTrader.Api.WebSockect
{
    public class WebSocketFeedService : BaseService, IWebSocketFeedService
    {
        public WebSocketFeedService(ApiClient apiClient, ILogger logger) : base(apiClient, logger)
        {
        }

       

        public async Task<bool> StartServiceFeed()
        {
            return await Task.FromResult(true);

        }

    }
}
