using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class TipoUsuarioDto
    {
        public TipoUsuarioDto()
        {
            
        }

        public TipoUsuarioDto(TipoUsuario tipoUsuario)
        {
            Id = tipoUsuario.Id;
            Nome = tipoUsuario.Nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
