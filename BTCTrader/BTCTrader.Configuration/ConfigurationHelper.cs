using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace BTCTrader.Configuration
{
    public class ConfigurationHelper
    {
        IConfigurationBuilder _configurationBuilder;
        public ConfigurationHelper(IConfigurationBuilder configurationBuilder)
        {
            _configurationBuilder = configurationBuilder;
        }

        public AppSettings GetAppSettings()
        {
            return _configurationBuilder.Build().GetSection("AppSettings").Get<AppSettings>();
        }
    }
}
