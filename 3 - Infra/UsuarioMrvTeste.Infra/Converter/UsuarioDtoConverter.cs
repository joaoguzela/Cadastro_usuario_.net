using System;
using System.Collections.Generic;
using System.Text;
using UsuarioMrvTeste.Domain;
using UsuarioMrvTeste.Domain.Models;

namespace UsuarioMrvTeste.Infra.Converter
{
    public class UsuarioDtoConverter : ITwoWayConverter<Usuario, UsuarioDto>
    {
        public UsuarioDto Convert(Usuario source)
        {
            return new UsuarioDto
            {
                idUsuario = source.idUsuario,
                nomeUsuario = source.nomeUsuario,
                emailUsuario = source.emailUsuario,
                senhaUsuario = source.senhaUsuario,

            };
        }

        public Usuario Convert(UsuarioDto source)
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
