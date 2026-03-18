using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IPedidoVendaService 
    {
        Task<IEnumerable<PedidoVendaDto>> ObterTodosPedidosVendas();
    }
}
