using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterTodosAsync();
        Task<IEnumerable<ProdutoDto>> ObterPorIdCategoria(int categoriaId);
        Task<ProdutoDto> ObterPorId(int id);
        Task<IEnumerable<ProdutoDto>> ObterProdutosDigitados(string query);
        Task<ProdutoDto> AtualizarProduto(int id, ProdutoDto produtoDto);
        Task<ProdutoDto> AdicionarProduto(ProdutoDto produto);

        Task<bool> DeletarProduto(int id);
    }
}
