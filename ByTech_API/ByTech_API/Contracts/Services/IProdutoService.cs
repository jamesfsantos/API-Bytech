using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterTodosAsync();
        Task<IEnumerable<ProdutoDto>> ObterPorIdCategoria(int categoriaId);
        
        Task<ProdutoDto> AdicionarProduto(ProdutoDto produto);
    }
}
