﻿using BTCTrader.Entities;
using Microsoft.Extensions.Configuration;

namespace BTCTrader.Configuration
{
    public class JsonFileConfiguration : ConfigurationBuilder, IAppSettingsConfiguration
    {
        AppSettings _appSettings = null;
        public JsonFileConfiguration(string appSettingsFilePath = BTCTrader.Constants.Configuration.FILE_CONFIGURATION)
        {
            this.AddJsonFile(appSettingsFilePath);
            _appSettings = Build().GetSection("AppSettings").Get<AppSettings>();
        }

        public AppSettings GetAppSettings()
        {
            return _appSettings;
        }
    }
}