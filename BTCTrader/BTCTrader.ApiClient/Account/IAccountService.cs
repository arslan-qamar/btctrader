using BTCTrader.Models.Account;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Account
{
    public interface IAccountService
    {
        Task<TradingFeesModel> GetTradingFees();
        Task<List<AssetModel>> GetAssetsAsync();
        Task<List<TransactionModel>> GetTransactionsAsync(AssetModel asset = null, Int64? before = null, Int64? after = null, int limit = 10);
    }
}