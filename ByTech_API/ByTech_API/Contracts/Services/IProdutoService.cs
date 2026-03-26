using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterTodosAsync();
    }
}
