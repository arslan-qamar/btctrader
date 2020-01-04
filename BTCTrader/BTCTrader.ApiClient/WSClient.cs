using BTCTrader.Entities;
using BTCTrader.Entities.Feed;
using BTCTrader.Models.Feed.Event;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly int _bufferSize;
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
            _bufferSize = appSettings.WssBufferSize;
            _wsocket.ConnectAsync(_wssBaseUrl, CancellationToken.None).Wait();

            if (_wsocket.State == WebSocketState.Open)
            {
                _logger.Information("Web Socket Connection Opened Successfully Base Url : {0}", _wssBaseUrl);

            }
        }

        public async Task Subscribe(List<string> channels, List<string> marketIds, Func<string, string, bool> eventReceivedCallBackFunc)
        {
            string message = BuildSubscribeRequest(channels, marketIds);

            ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await _wsocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, _cancellationToken);

            WebSocketReceiveResult result = null;
            ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[_bufferSize]);
            MemoryStream memoryStream = new MemoryStream();

            while (!_cancellationToken.IsCancellationRequested)
            {
                memoryStream.SetLength(0); //reset Memory Stream
                do
                {                    
                    result = await _wsocket.ReceiveAsync(bytesReceived, _cancellationToken);
                    if (result.Count > 0)
                    {
                        memoryStream.Write(bytesReceived.Array, bytesReceived.Offset, result.Count);
                    }
                    else
                    {
                        _logger.Warning("WS received zero: {0}, {1} , Skipping over.", result.Count, _wsocket.State);
                        continue;
                    }
                } while (!result.EndOfMessage); // check end of message mark

                
                var receivedMessage = Encoding.UTF8.GetString(memoryStream.ToArray(), 0 , memoryStream.ToArray().Length);
                var receivedEvent = JsonConvert.DeserializeObject<BaseFeedEventModel>(receivedMessage);
                eventReceivedCallBackFunc(receivedEvent.EventType, receivedMessage);
            }
               
        }
    

        private String BuildSubscribeRequest(List<string> channels, List<string> marketIds)
        {
            JObject obj = new JObject();
            obj.Add("channels", JToken.FromObject(channels));
            obj.Add("marketIds", JToken.FromObject(marketIds));
            obj.Add("messageType", JToken.FromObject(MessageType.Subscribe));

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
