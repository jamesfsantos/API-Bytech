using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ByTech_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            _configuration = configuration;

        }

        private bool VerificarSenha(string senhaDigitada, string senhaHash, string saltBanco)
        {

            string senhaComSalt = senhaDigitada + saltBanco;

            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaComSalt));


                string hashGerado = Convert.ToBase64String(bytes);


                return hashGerado.Equals(senhaHash);
            }
        }

        public string Autenticar(LoginDto loginDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == loginDto.Email);

            if (usuario == null) return null;

            bool validarSenha = VerificarSenha(loginDto.Senha, usuario.Senha, usuario.SenhaSalt);

            if (!validarSenha) return null;


            return GerarToken(usuario.Email, usuario.TipoUsuarioId.ToString());

        }

        public string GerarToken(string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
