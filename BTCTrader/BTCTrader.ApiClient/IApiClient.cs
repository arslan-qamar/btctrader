using BTCTrader.Models;
using System.Threading.Tasks;

namespace BTCTrader.Api
{
    public interface IApiClient
    {
        Task<ResponseModel> Delete(string path, string queryString);
        Task<ResponseModel> Get(string path, string queryString);
        Task<ResponseModel> Post(string path, string queryString, object data);
        Task<ResponseModel> Put(string path, string queryString, object data);
    }
}