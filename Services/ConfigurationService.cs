using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Medical.Services
{
    //klasa pomocnicza do wczytania konfiguracji z pliku appsettings.json
    public class ConfigurationService
    {
        private readonly IConfiguration _configuration;

        #region Konstruktor
        public ConfigurationService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }
        #endregion

        public string GetGeminiApiKey()
        {
            var apiKey = _configuration["Gemini:ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey) || apiKey == "YOUR_API_KEY_HERE")
            {
                throw new InvalidOperationException(
                    "Gemini API Key not configured. Please add your API key to appsettings.json");
            }

            return apiKey;
        }
    }
}
