using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using UsuarioMrvTeste.Infra.Interfaces;

namespace UsuarioMrvTeste.Infra
{
   public class AzureTableFactory : IAzureTableFactory
    {
        private readonly CloudStorageAccount _storageAccount;

        public AzureTableFactory(CloudStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
        }

        public CloudTable ObterTabela(string nomeTabela)
        {
            var tableClient = _storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference(nomeTabela);
        }

    }
}
