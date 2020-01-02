using System.Net.WebSockets;
using System.Threading.Tasks;

namespace BTCTrader.Api
{
    public interface IWSClient
    {
        Task<ClientWebSocket> GetWebSocketClient();
    }
}