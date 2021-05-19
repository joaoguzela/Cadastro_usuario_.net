using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioMrvTeste.Infra.Interfaces
{
   public interface IAzureTableDataBase
    {
        Task<TableResult> InserirEntidadeAsync(string nomeTabela, TableEntity entidade);
    }
}
