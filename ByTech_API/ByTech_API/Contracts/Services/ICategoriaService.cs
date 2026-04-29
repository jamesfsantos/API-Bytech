using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> ObterTodosAsync();
    }
}
