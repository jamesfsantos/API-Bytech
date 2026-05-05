using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;


namespace ByTech_API.Services
{
    public class ItemPedidoService : IItemService
    {
        private readonly AppDbContext _context;

        public ItemPedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemPedidoDto>> ObterTodos()
        {
            var itens = await _context.ItensPedidos.ToListAsync();

            if (itens == null || !itens.Any())
                return null;

            return itens.Select(i => new ItemPedidoDto(i));
        }
    }
}
