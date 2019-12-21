using BTCTrader.Models.Account;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Account
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(ApiClient apiClient, ILogger logger) : base(apiClient, logger)
        {
        }

        public async Task<List<AssetModel>> GetAssetsAsync()
        {
            var result = await _apiClient.Get($"{VERSION}accounts/me/balances", string.Empty);            
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetModel>>(result.Content);
        }

    }
}
