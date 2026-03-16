using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;


namespace ByTech_API.Services
{
    public class UsuarioService : IUsuariosService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<UsuarioDto>> ObterTodos()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };


            if (usuarios==null || !usuarios.Any())
                return null;


            
           return usuarios.Select(usuario => new UsuarioDto(usuario));
        }
    }
}
