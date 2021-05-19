using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using System;

namespace UsuarioMrvTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                 {
                     var configBuilt = config.Build();
                     var azureServiceTokenProvider = new AzureServiceTokenProvider();
                     var keyVaultClient = new KeyVaultClient(
                     new KeyVaultClient.AuthenticationCallback(
                     azureServiceTokenProvider.KeyVaultTokenCallback
                     )
                     );
                     config.AddAzureKeyVault(
                     configBuilt["KeyVault:VaultUrl"],
                     keyVaultClient,
                     new DefaultKeyVaultSecretManager()
                     );
                 })    
              .ConfigureServices(services => services.AddAutofac())
              .UseStartup<Startup>();
    }
}