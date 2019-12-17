using BTCTrader.Entities;

namespace BTCTrader.Configuration
{
    public interface IAppSettingsConfiguration
    {
        AppSettings GetAppSettings();
    }
}