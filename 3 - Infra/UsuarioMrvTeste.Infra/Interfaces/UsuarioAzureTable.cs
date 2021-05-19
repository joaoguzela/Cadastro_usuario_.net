using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsuarioMrvTeste.Domain.Models;
using UsuarioMrvTeste.Domain.Repository;
using UsuarioMrvTeste.Infra.Converter;
using UsuarioMrvTeste.Infra.Entity;

namespace UsuarioMrvTeste.Infra.Interfaces
{
    public class UsuarioAzureTable : IUsuarioRepository
    {
        private readonly IAzureTableDataBase _database;
        private readonly ITwoWayConverter<Usuario, UsuarioEntity> _convert;
        public UsuarioAzureTable(
            IAzureTableDataBase database,
            ITwoWayConverter<Usuario, UsuarioEntity> convert
            )
        {
            _database = database;
            _convert = convert;
        }


        public async Task<bool> SalvarAsync(Usuario usuario)
        {

            if (usuario == null) return false;

            
            var usuarioAserSalvo = _convert.Convert(usuario);
            usuarioAserSalvo.PartitionKey = usuarioAserSalvo.idUsuario;
            usuarioAserSalvo.RowKey = usuarioAserSalvo.nomeUsuario;

            await _database.InserirEntidadeAsync(typeof(UsuarioEntity).Name, usuarioAserSalvo);
            
            return true;
        
        }

    }
}
