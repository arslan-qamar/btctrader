using Serilog;

namespace BTCTrader.Api
{
    public class BaseService
    {
        public const string VERSION = "/v3/";
        protected internal readonly ApiClient _apiClient;
        protected internal readonly ILogger _logger;

        public BaseService(ApiClient apiClient, ILogger logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }
    }
}
