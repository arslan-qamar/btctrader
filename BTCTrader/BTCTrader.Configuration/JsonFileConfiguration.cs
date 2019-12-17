using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;

namespace BTCTrader.Configuration
{
    public class JsonFileConfiguration : ConfigurationBuilder, IAppSettingsConfiguration
    {
        private AppSettings _appSettings = null;
        public JsonFileConfiguration(string appSettingsFilePath = BTCTrader.Constants.Configuration.FILE_CONFIGURATION)
        {
            this.AddJsonFile(appSettingsFilePath);
            _appSettings = Build().GetSection(Constants.Configuration.FILE_APPSETTINGS_SECTIONNAME).Get<AppSettings>();
        }

        public AppSettings GetAppSettings()
        {
            return _appSettings;
        }
    }
}
