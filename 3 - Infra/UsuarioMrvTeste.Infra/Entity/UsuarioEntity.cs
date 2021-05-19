using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsuarioMrvTeste.Infra.Entity
{
    public class UsuarioEntity : TableEntity
    {
        
        public string idUsuario { get; set; }

        
        public string nomeUsuario { get; set; }

        
        public string emailUsuario { get; set; }

        
        public String senhaUsuario { get; set; }
    }
}
