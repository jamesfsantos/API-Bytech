using ByTech_API.Contracts.Services;
using ByTech_API.Dtos;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByTech_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioService _usuarioService;

        public AuthController(IAuthService authService, IUsuarioService usuarioService)
        {
            _authService = authService;
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            // 2. Valida no banco
            var usuario = await _usuarioService.ObterPorEmail(login.Email);

            // 3. Na hora de gerar o token e o retorno, IGNORE o login.Role 
            // e use o dadosUsuario.TipoUsuario
            var token = _authService.GerarToken(
                usuario.Email,
                usuario.TipoUsuario.Nome, 
                usuario.Nome
            );

            return Ok(new
            {
                token = token,
                usuarioEmail = usuario.Email,
                usuarioNome = usuario.Nome,
                role = usuario.TipoUsuario.Nome 
            });
        }
    }
}
