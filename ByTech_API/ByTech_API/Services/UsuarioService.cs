using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Extensions;
using ByTech_API.Models;
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
                Cpf = usuario.Cpf,
                Endereco = usuario.Endereco,
                Complemento = usuario.Complemento,
                Cidade = usuario.Cidade,
                Cep = usuario.Cep,
                TipoUsuarioId = usuario.TipoUsuarioId

            });

        }

        public async Task<UsuarioDto> AtualizarUsuario(int id, UsuarioDto usuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return null;

            usuario.AtualizaParaUsuarioDto(usuarioDto);

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
                Endereco = usuario.Endereco,
                Complemento = usuario.Complemento,
                Cidade = usuario.Cidade,
                Cep = usuario.Cep,
                TipoUsuario = new TipoUsuarioDto
                {
                    Id = usuario.TipoUsuario.Id,
                    Nome = usuario.TipoUsuario.Nome
                }
            };
        }

        public static string FormatarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return string.Empty;

            var apenasNumeros = new string(cpf.Where(char.IsDigit).ToArray());

            if (apenasNumeros.Length == 11)
            {
                return Convert.ToUInt64(apenasNumeros).ToString(@"000\.000\.000\-00");
            }

            return apenasNumeros;
        }

        public static string FormataCep(string cep)
        {
            if (string.IsNullOrEmpty(cep)) return string.Empty;
            var apenasNumeros = new string(cep.Where(char.IsDigit).ToArray());

            if (apenasNumeros.Length == 8)
            {
                return Convert.ToUInt64(apenasNumeros).ToString(@"00000\-000");
            }
            return apenasNumeros;
        }

        public static string FormatarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone)) return string.Empty;
            var apenasNumeros = new string(telefone.Where(char.IsDigit).ToArray());

            if (apenasNumeros.Length == 11)
            {
                return long.Parse(apenasNumeros).ToString(@"(00) 00000-0000");
            }
            else if (apenasNumeros.Length == 10)
            {
                return long.Parse(apenasNumeros).ToString(@"(00) 0000-0000");
            }

            return apenasNumeros;
        }

        public async Task<UsuarioDto> AdicionarUsuario(UsuarioDto usuarioDto)
        {


            byte[] saltBytes = RandomNumberGenerator.GetBytes(32);
            string saltString = Convert.ToBase64String(saltBytes);


            byte[] senhaComSaltBytes = Encoding.UTF8.GetBytes(usuarioDto.Senha + saltString);
            byte[] hashBytes = SHA256.HashData(senhaComSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);


            var emailExiste = _context.Usuarios.Any(x => x.Email == usuarioDto.Email);
            if (emailExiste)
            {
                throw new Exception("Email existente, insira outro.");
            }
            var cpfExiste = _context.Usuarios.Any(x => x.Cpf == usuarioDto.Cpf);
            if (cpfExiste)
            {
                throw new Exception("CPF já cadastrado, insira outro");
            }
            var celularExiste = _context.Usuarios.Any(x => x.Celular == usuarioDto.Celular);
            if (celularExiste)
            {
                throw new Exception("Celular já cadastrado, insira outro.");
            }

            else
            {
                var usuario = new Usuario
                {
                    Nome = usuarioDto.Nome,
                    Email = usuarioDto.Email,
                    Senha = hashString,
                    SenhaSalt = saltString,
                    Celular = FormatarTelefone(usuarioDto.Celular),
                    Endereco = usuarioDto.Endereco,
                    Complemento = usuarioDto.Complemento,
                    Cpf = FormatarCpf(usuarioDto.Cpf),
                    Cidade = usuarioDto.Cidade,
                    Cep = FormataCep(usuarioDto.Cep),
                    TipoUsuarioId = 2
                };

                _context.Usuarios.Add(usuario);

                await _context.SaveChangesAsync();
                usuarioDto.Id = usuario.Id;
                return usuarioDto;
            }



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

        public async Task<UsuarioDto> ObterPorEmail(string email)
        {
            var usuario = await _context.Usuarios.Include(x => x.TipoUsuario).FirstOrDefaultAsync(x => x.Email == email);

            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuarioId = usuario.TipoUsuarioId,
                Cpf = usuario.Cpf,
                Celular = usuario.Celular,
                Endereco = usuario.Endereco,
                Complemento = usuario.Complemento,
                Cidade = usuario.Cidade,
                Cep = usuario.Cep,
                TipoUsuario = new TipoUsuarioDto
                {
                    Id = usuario.TipoUsuario.Id,
                    Nome = usuario.TipoUsuario.Nome
                }
            };
        }
    }
}
