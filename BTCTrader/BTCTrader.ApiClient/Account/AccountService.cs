using BTCTrader.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Account
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly ApiClient _apiClient;

        public AccountService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<AssetModel>> GetAssetsAsync()
        {
            var result = await _apiClient.Get($"{VERSION}accounts/me/balances", string.Empty);            
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetModel>>(result.Content);
        }

    }
}
