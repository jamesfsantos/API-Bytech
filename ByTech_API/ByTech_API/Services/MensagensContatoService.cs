using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class MensagensContatoService : IMensagensContatoService
    {
        private readonly AppDbContext _context;
        public MensagensContatoService(AppDbContext context) { 
        
        _context = context;
        }


        public async Task<IEnumerable<MensagensContatoDto>> ObterTodos()
        {
         var mensagens = await _context.MensagensContatos.ToListAsync();

            if (mensagens == null || !mensagens.Any())
            {
                return null;
            }
            return mensagens.Select(e => new MensagensContatoDto(e));
        }
    }
}
