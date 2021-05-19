using System;
using System.Collections.Generic;
using System.Text;

namespace UsuarioMrvTeste.Infra.Interfaces
{
    public interface IApplicationSettings
    {
        string AzureTableStorageConnectionString { get; }
        string KeyvaultUrl { get; }
    }
}
