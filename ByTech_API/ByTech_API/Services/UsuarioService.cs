using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace ByTech_API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<UsuarioDto>> ObterTodos()
        {
            var usuarios = await _context.Usuarios.Include(x => x.TipoUsuario).ToListAsync();

            if (usuarios == null || !usuarios.Any())
                return null;

            return usuarios.Select(usuario => new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Celular = usuario.Celular,
                TipoUsuarioId = usuario.TipoUsuarioId
            
            });

        }

        public async Task<UsuarioDto> AtualizarUsuario(int id, UsuarioDto usuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return null;

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Senha = usuarioDto.Senha;
            usuario.Celular = usuarioDto.Celular;

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return usuarioDto;
        }

        public async Task<UsuarioDto> ObterPorId(int id)
        {
            var usuario = await _context.Usuarios.Include(x => x.TipoUsuario).FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuarioId = usuario.TipoUsuarioId,
                Celular = usuario.Celular,
                TipoUsuario = new TipoUsuarioDto
                {
                    Id = usuario.TipoUsuario.Id,
                    Nome = usuario.TipoUsuario.Nome
                }
            };
        }

        public async Task<UsuarioDto> AdicionarUsuario(UsuarioDto usuarioDto)
        {


            byte[] saltBytes = RandomNumberGenerator.GetBytes(32);
            string saltString = Convert.ToBase64String(saltBytes);

            // 2. Combinar a senha digitada com o Salt e gerar o Hash
            byte[] senhaComSaltBytes = Encoding.UTF8.GetBytes(usuarioDto.Senha + saltString);
            byte[] hashBytes = SHA256.HashData(senhaComSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);




            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = hashString,
                SenhaSalt = saltString,
                Celular = usuarioDto.Celular,
                TipoUsuarioId = 2
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

        public async Task<bool> ValidarLogin(string email, string senhaDigitada)
        {

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null) return false;


            byte[] bytesParaVerificar = Encoding.UTF8.GetBytes(senhaDigitada + usuario.SenhaSalt);
            byte[] hashDigitadoBytes = SHA256.HashData(bytesParaVerificar);
            string hashDigitadoString = Convert.ToBase64String(hashDigitadoBytes);
            return CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(hashDigitadoString),
                Encoding.UTF8.GetBytes(usuario.Senha)
            );
        }
    }
}
