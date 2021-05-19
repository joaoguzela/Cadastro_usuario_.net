using Autofac;

using Microsoft.WindowsAzure.Storage;
using UsuarioMrvTeste.Domain;
using UsuarioMrvTeste.Domain.Models;
using UsuarioMrvTeste.Domain.Repository;
using UsuarioMrvTeste.Infra;
using UsuarioMrvTeste.Infra.Converter;
using UsuarioMrvTeste.Infra.Entity;
using UsuarioMrvTeste.Infra.Interfaces;

namespace UsuarioMrvTeste
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurarInjecoesDomainLayer(builder);
            ConfigurarInjecoesInfrastructureLayer(builder);
        }

        private void ConfigurarInjecoesDomainLayer(ContainerBuilder builder)
        {
            builder.RegisterType<UsuarioAzureTable>().As<IUsuarioRepository>();
        }

        private void ConfigurarInjecoesInfrastructureLayer(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IApplicationSettings>();

                return CloudStorageAccount.Parse(config.AzureTableStorageConnectionString);
            }).As<CloudStorageAccount>().SingleInstance();

            builder.RegisterType<AzureTableFactory>().As<IAzureTableFactory>();
            builder.RegisterType<AzureTableDataBase>().As<IAzureTableDataBase>();
            builder.RegisterType<UsuarioAzureTable>().As<IUsuarioRepository>();
            builder.RegisterType<UsuarioEntityConverter>().As<ITwoWayConverter<Usuario, UsuarioEntity>>();
            builder.RegisterType<UsuarioDtoConverter>().As<ITwoWayConverter<Usuario, UsuarioDto>>();
        }
    }
}