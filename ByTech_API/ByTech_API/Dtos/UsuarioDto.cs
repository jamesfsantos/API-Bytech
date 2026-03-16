using ByTech_API.Enums;
using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {

        }

        public UsuarioDto(Usuarios usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Senha= usuario.Senha;
            TipoUsuario=usuario.TipoUsuario;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }


    }
}
