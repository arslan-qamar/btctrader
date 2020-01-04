using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTCTrader.Api
{
    public interface IWSClient
    {
        Task Subscribe(List<string> channels, List<string> marketIds, Func<string, string, bool> eventReceivedCallBackFunc);
    }
}