using BTCTrader.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api.Account
{
    public interface IAccountService
    {
        Task<List<AssetModel>> GetAssetsAsync();
    }
}