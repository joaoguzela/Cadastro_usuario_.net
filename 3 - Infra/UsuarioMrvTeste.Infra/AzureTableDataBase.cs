using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsuarioMrvTeste.Infra.Interfaces;

namespace UsuarioMrvTeste.Infra
{
   public class AzureTableDataBase : IAzureTableDataBase
    {
        private readonly IAzureTableFactory _tableFactory;

        public AzureTableDataBase(IAzureTableFactory tableFactory)
        {
            _tableFactory = tableFactory;
        }

        public Task<TableResult> InserirEntidadeAsync(string nomeTabela, TableEntity entidade)
        {
            var table = _tableFactory.ObterTabela(nomeTabela);
            return table.ExecuteAsync(TableOperation.Insert(entidade));
        }


    }
}
