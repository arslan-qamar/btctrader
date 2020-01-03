using BTCTrader.Models.Account;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Account
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IApiClient apiClient, ILogger logger) : base(apiClient, logger)
        {
        }

        public async Task<List<AssetModel>> GetAssetsAsync()
        {
            var result = await _apiClient.Get($"{VERSION}accounts/me/balances", string.Empty);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetModel>>(result.Content);
        }

        public async Task<List<TransactionModel>> GetTransactionsAsync(AssetModel asset, Int64? before, Int64? after, int limit = 0)
        {
            var result = await _apiClient.Get($"{VERSION}accounts/me/transactions", $"assetName={asset?.AssetName}&before={before}&after={after}&limit={limit}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<TransactionModel>>(result.Content);
        }
    }
}
