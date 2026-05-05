using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IPedidoService 
    {
        Task<IEnumerable<PedidoDto>> ObterTodosPedidos();
        Task<PedidoDto> AdicionarPedido(PedidoDto pedido);
        Task<IEnumerable<PedidoDto>> ObterTodosPedidosEmail(string email);
    }
}
