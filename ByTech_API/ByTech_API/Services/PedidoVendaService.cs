using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class PedidoVendaService : IPedidoVendaService
    {
        private readonly AppDbContext _context;
        public PedidoVendaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PedidoVendaDto>> ObterTodosPedidosVendas()
        {
            var pedidos = await _context.PedidosVenda.ToListAsync();

            if (pedidos == null || !pedidos.Any())
                return null;

            return pedidos.Select(pedido => new PedidoVendaDto(pedido));
        }
    }
}
