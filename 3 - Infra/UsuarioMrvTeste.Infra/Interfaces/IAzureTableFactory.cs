using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsuarioMrvTeste.Infra.Interfaces
{
   public interface IAzureTableFactory
    {
        CloudTable ObterTabela(string nomeTabela);
    }
}
