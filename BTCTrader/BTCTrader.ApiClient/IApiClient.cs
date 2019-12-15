using BTCTrader.Models;
using System.Threading.Tasks;

namespace BTCTrader.Api
{
    public interface IApiClient
    {
        Task<string> Delete(string path, string queryString);
        Task<ResponseModel> Get(string path, string queryString);
        Task<string> Post(string path, string queryString, object data);
        Task<string> Put(string path, string queryString, object data);
    }
}