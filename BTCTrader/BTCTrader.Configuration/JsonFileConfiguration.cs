using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace BTCTrader.Configuration
{
    public class JsonFileConfiguration : ConfigurationBuilder, ITradingSystemConfiguration
    {
        private AppSettings _appSettings = null;
        private LoggerConfiguration _loggerConfiguration = null;
        public JsonFileConfiguration(string appSettingsFilePath = BTCTrader.Constants.Configuration.FILE_CONFIGURATION)
        {
            this.AddJsonFile(appSettingsFilePath);
            IConfigurationRoot configurationRoot = Build();
            _appSettings = configurationRoot.GetSection(Constants.Configuration.FILE_APPSETTINGS_SECTIONNAME).Get<AppSettings>();
            _loggerConfiguration = new LoggerConfiguration().ReadFrom.Configuration(configurationRoot);
        }

        public AppSettings GetAppSettings()
        {
            return _appSettings;            
        }

        public LoggerConfiguration GetLoggerConfiguration()
        {
            return _loggerConfiguration;
        }
    }
}
