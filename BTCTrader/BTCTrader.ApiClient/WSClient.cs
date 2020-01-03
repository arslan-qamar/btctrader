using BTCTrader.Entities;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BTCTrader.Api
{
    public class WSClient : IWSClient
    {
        
        private readonly Uri _wssBaseUrl;
        private readonly string _apiKey;
        private readonly string _privateKey;
        private readonly ILogger _logger;
        private ClientWebSocket _wsocket;
        private CancellationToken _cancellationToken;

        public WSClient(AppSettings appSettings, CancellationToken cancellationToken, ILogger logger)
        {
            _apiKey = appSettings.ApiKey;
            _privateKey = appSettings.PrivateKey;
            _wssBaseUrl = new Uri(appSettings.WssBaseUrl);
            _wsocket = new ClientWebSocket();
            _logger = logger;
            _cancellationToken = cancellationToken;

            _wsocket.ConnectAsync(_wssBaseUrl, CancellationToken.None).Wait();

            if (_wsocket.State == WebSocketState.Open)
            {
                _logger.Information("Web Socket Connection Opened Successfully Base Url : {0}", _wssBaseUrl);

            }
        }

        public async Task Subscribe(List<string> channels, List<string> marketIds)
        {
            string message = BuildSubscribeRequest(channels, marketIds);

            ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await _wsocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, _cancellationToken);

            while (!_cancellationToken.IsCancellationRequested)
            {
                ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await _wsocket.ReceiveAsync(bytesReceived, _cancellationToken);
                Console.WriteLine(Encoding.UTF8.GetString(bytesReceived.Array, 0, result.Count));
            }            
        }

        private String BuildSubscribeRequest(List<string> channels, List<string> marketIds)
        {
            JObject obj = new JObject();
            obj.Add("channels", JToken.FromObject(channels));
            obj.Add("marketIds", JToken.FromObject(marketIds));
            obj.Add("messageType", JToken.FromObject("subscribe"));

            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            String strToSign = buildStringToSign("/users/self/subscribe", timestamp);
            String signature = SignMessage(strToSign);
            obj.Add("signature", signature);
            obj.Add("timestamp", timestamp);
            obj.Add("key", _apiKey);

            return obj.ToString();
        }

        private static String buildStringToSign(String path, long timestamp)
        {
            return path + "\n" + timestamp;
        }

        private string SignMessage(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);

            using (var hash = new HMACSHA512(Convert.FromBase64String(_privateKey)))
            {
                var hashedInputeBytes = hash.ComputeHash(bytes);
                return Convert.ToBase64String(hashedInputeBytes);
            }
        }

    }
}
