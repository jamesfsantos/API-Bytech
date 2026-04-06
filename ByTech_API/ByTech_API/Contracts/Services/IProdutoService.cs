using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterTodosAsync();
        Task<ProdutoDto> ObterPorId(int id);
        Task<List<ProdutoDto>> ObterPorCategoria(string categoria);
        Task<ProdutoDto> AdicionarProduto(ProdutoDto produto);
    }
}
