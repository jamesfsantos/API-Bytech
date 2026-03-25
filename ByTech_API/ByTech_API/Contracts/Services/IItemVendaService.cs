using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IItemVendaService
    {
        Task<IEnumerable<ItemVendaDto>> ObterTodos();
    }
}
