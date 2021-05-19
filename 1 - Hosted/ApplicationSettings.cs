using Microsoft.Extensions.Configuration;
using UsuarioMrvTeste.Infra.Interfaces;

namespace UsuarioMrvTeste
{
    public class ApplicationSettings : IApplicationSettings
    {
        private readonly IConfiguration _configProvider;

        public ApplicationSettings(IConfiguration configProvider)
        {
            _configProvider = configProvider;
        }

        private TType GetValueFromConfig<TType>(string key)
        {
            return _configProvider
                .GetSection("AppConfiguration")
                .GetValue<TType>(key);
        }

        public string AzureTableStorageConnectionString => GetValueFromConfig<string>("AzureTableStorageConnectionString");

        public string KeyvaultUrl => _configProvider.GetValue<string>("KeyVault:VaultUrl");
    }
}