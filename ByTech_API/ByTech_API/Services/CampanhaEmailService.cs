using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class CampanhaEmailService : ICampanhaEmailService
    {
        private readonly AppDbContext _context;
        public CampanhaEmailService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CampanhaEmailDto>> ObterTodos()
        {
            var emails = await _context.CampanhasEmails.ToListAsync();
            if (emails == null || !emails.Any())
            {
                return null;
            }
            return emails.Select(e => new CampanhaEmailDto(e));
        }
    }
}
