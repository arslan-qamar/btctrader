using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BTCTrader.Api.WebSockect
{
    public class WebSocketFeedService : IWebSocketFeedService
    {
        private IWSClient _wsClient;
        private ILogger _logger;
        public WebSocketFeedService(IWSClient wsClient, ILogger logger) 
        {
            _wsClient = wsClient;
            _logger = logger;
        }


        public void Subscribe(List<String> channels, List<String> marketIds)
        {
            _wsClient.Subscribe(channels, marketIds);
        }


    }
}
