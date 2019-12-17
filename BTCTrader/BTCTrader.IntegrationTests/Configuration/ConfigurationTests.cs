using BTCTrader.Configuration;
using BTCTrader.Entities;
using Xunit;

namespace BTCTrader.IntegrationTests.Configuration
{
    public class ConfigurationTests 
    {
        [Fact]
        public void GetAppSettingsFromJsonFileConfigurationAsync()
        {
            JsonFileConfiguration jsonFileConfiguration = new JsonFileConfiguration(Constants.Configuration.FILE_CONFIGURATION);
            AppSettings appSettings = jsonFileConfiguration.GetAppSettings();

            Assert.True(!string.IsNullOrEmpty(appSettings.ApiKey) , $"ApiKey loaded values is : {appSettings.ApiKey}");
            Assert.True(!string.IsNullOrEmpty(appSettings.BaseUrl), $"BaseUrl loaded values is : {appSettings.BaseUrl}");
            Assert.True(!string.IsNullOrEmpty(appSettings.PrivateKey), $"PrivateKey loaded values is : {appSettings.PrivateKey}");
        }
    }
}
