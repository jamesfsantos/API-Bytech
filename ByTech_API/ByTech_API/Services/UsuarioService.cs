using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

            if (usuarios==null || !usuarios.Any())
                return null;
            
           return usuarios.Select(usuario => new UsuarioDto(usuario));
        }

        public async Task<UsuarioDto> AtualizarUsuario(int id, UsuarioDto usuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return null;

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Senha = usuarioDto.Senha;

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return usuarioDto;
        }

        public async Task<UsuarioDto> ObterPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                TipoUsuario = usuario.TipoUsuario
            };
        }

        public async Task<UsuarioDto> AdicionarUsuario(UsuarioDto usuarioDto)
        {
            var usuario = new Usuarios 
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = usuarioDto.Senha,
                TipoUsuario = usuarioDto.TipoUsuario
            };

            _context.Usuarios.Add(usuario);

            await _context.SaveChangesAsync();
            usuarioDto.Id = usuario.Id;
            return usuarioDto;
            

        }

        public async Task<bool> ExcluirUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
