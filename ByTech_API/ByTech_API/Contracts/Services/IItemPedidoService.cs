using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemPedidoDto>> ObterTodos();
    }
}
