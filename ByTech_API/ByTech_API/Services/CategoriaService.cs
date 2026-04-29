using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoriaDto>> ObterTodosAsync()
        {
            // Pegando todas as categorias do banco de dados...
            var categorias = await _context.Categorias.ToListAsync();

            if(!categorias.Any()) 
                return null;

            return categorias.Select(c => new CategoriaDto { Id = c.Id, Nome = c.Nome });
        }
    }
}
