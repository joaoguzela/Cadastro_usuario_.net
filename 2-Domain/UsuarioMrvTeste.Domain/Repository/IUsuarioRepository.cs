using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsuarioMrvTeste.Domain.Models;

namespace UsuarioMrvTeste.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<bool> SalvarAsync(Usuario usuario);
    }
}
