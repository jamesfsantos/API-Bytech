using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;


namespace ByTech_API.Services
{
    public class ItemVendaService : IItemVendaService
    {
        private readonly AppDbContext _context;

        public ItemVendaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemVendaDto>> ObterTodos()
        {
            var itens = await _context.ItensVendas.ToListAsync();

            if (itens == null || !itens.Any())
                return null;

            return itens.Select(i => new ItemVendaDto(i));
        }
    }
}
