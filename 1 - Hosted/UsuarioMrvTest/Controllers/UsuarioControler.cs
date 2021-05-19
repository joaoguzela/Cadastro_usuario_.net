
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using UsuarioMrvTeste.Domain;
using UsuarioMrvTeste.Domain.Models;
using UsuarioMrvTeste.Domain.Repository;
using UsuarioMrvTeste.Infra.Converter;

namespace UsuarioMrvTeste.Controllers
{
    [Route("api/CadastroUsuario")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UsuarioControler : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITwoWayConverter<Usuario, UsuarioDto> _converter;

        public UsuarioControler(
           IUsuarioRepository usuarioRepository,
           ITwoWayConverter<Usuario, UsuarioDto> converter
        )
        {
            _usuarioRepository = usuarioRepository;
            _converter = converter;
        }

        [HttpPost]
        public async Task<IActionResult> CadatroUsuario([FromBody] UsuarioDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuarioCadastro = _converter.Convert(usuario);

            var usuarioAdicionado = await _usuarioRepository.SalvarAsync(usuarioCadastro);

            return Ok(usuarioAdicionado);
        }
    }
}