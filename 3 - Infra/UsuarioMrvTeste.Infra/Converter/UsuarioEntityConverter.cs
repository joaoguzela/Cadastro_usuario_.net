using UsuarioMrvTeste.Domain.Models;
using UsuarioMrvTeste.Infra.Entity;

namespace UsuarioMrvTeste.Infra.Converter
{
    public class UsuarioEntityConverter : ITwoWayConverter<Usuario, UsuarioEntity>
    {
        public UsuarioEntity Convert(Usuario source)
        {
            return new UsuarioEntity
            {
                idUsuario = source.idUsuario,
                nomeUsuario = source.nomeUsuario,
                emailUsuario = source.emailUsuario,
                senhaUsuario = source.senhaUsuario,

            };
        }

        public Usuario Convert(UsuarioEntity source)
        {
            return new Usuario
            {
                idUsuario = source.idUsuario,
                nomeUsuario = source.nomeUsuario,
                emailUsuario = source.emailUsuario,
                senhaUsuario = source.senhaUsuario,
            };
        }
    }
}

