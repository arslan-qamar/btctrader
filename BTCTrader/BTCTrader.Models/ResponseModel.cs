using System.Net.Http.Headers;

namespace BTCTrader.Models
{
    public class ResponseModel
    {
        public HttpResponseHeaders Headers { get; set; }
        public string Content { get; set; }
    }
}
