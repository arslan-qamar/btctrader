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
        private readonly string _baseUrl;
        private readonly string _wssBaseUrl;
        private readonly string _apiKey;
        private readonly string _privateKey;
        private readonly ILogger _logger;

        public WSClient(AppSettings appSettings, ILogger logger)
        {
            _baseUrl = appSettings.BaseUrl;
            _apiKey = appSettings.ApiKey;
            _privateKey = appSettings.PrivateKey;
            _wssBaseUrl = appSettings.WssBaseUrl;
            _logger = logger;

        }

        private String buildSubscribeRequest(List<String> channels, List<String> marketIds)
        {
            JObject obj = new JObject();
            obj.Add("channels", JToken.FromObject(channels));
            obj.Add("marketIds", JToken.FromObject(marketIds));
            obj.Add("messageType", JToken.FromObject("subscribe"));

            long timestamp = DateTimeOffset.Now.Ticks;
            String strToSign = buildStringToSign("/users/self/subscribe", timestamp);
            String signature = SignMessage(strToSign);
            //obj.Add("signature", signature);
            //obj.Add("timestamp", timestamp);
            //obj.Add("key", _apiKey);

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

        public async Task<ClientWebSocket> GetWebSocketClient()
        {
            using (ClientWebSocket ws = new ClientWebSocket())
            {
                Uri serverUri = new Uri(_wssBaseUrl);
                await ws.ConnectAsync(serverUri, CancellationToken.None);
                if (ws.State == WebSocketState.Open)
                {
                    _logger.Information("Web Socket Connection Opened Successfully Base Url : {0}", _wssBaseUrl);
                    
                    //Console.Write("Input message ('exit' to exit): ");
                    //string msg = Console.ReadLine();
                    //if (msg == "exit")
                    //{
                    //    break;
                    //}
                    //ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));
                    //await ws.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);
                    //ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[1024]);
                    //WebSocketReceiveResult result = await ws.ReceiveAsync(bytesReceived, CancellationToken.None);
                    //Console.WriteLine(Encoding.UTF8.GetString(bytesReceived.Array, 0, result.Count));
                }
                return ws;
            }
        }
    }
}
