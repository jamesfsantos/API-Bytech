
using ByTech_API.Models;
using System.Text.Json.Serialization;

namespace ByTech_API.Dtos
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {

        }

        public UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Senha= usuario.Senha;
            Celular = usuario.Celular;
            TipoUsuarioId = usuario.TipoUsuarioId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public int TipoUsuarioId { get; set; }
        [JsonIgnore]
        public TipoUsuarioDto? TipoUsuario { get; set; }


    }
}
