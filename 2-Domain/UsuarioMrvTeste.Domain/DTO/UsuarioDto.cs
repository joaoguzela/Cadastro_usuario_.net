using Newtonsoft.Json;
using System;

namespace UsuarioMrvTeste.Domain
{
    public class UsuarioDto
    {
        [JsonProperty("IdUsuario")]
        public string idUsuario { get; set; }

        [JsonProperty("NomeUsuario")]
        public string nomeUsuario { get; set; }

        [JsonProperty("EmailUsuario")]
        public string emailUsuario { get; set; }

        [JsonProperty("SenhaUsuario")]
        public String senhaUsuario { get; set; }
    }
}
