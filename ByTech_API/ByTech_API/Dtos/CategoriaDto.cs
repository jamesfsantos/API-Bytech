using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class CategoriaDto
    {
        public CategoriaDto()
        {}
        public CategoriaDto(Categoria categoria)
        {
            Id = categoria.Id;
            Nome = categoria.Nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
