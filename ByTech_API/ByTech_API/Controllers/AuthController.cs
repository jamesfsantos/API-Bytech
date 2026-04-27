using ByTech_API.Contracts.Services;
using ByTech_API.Dtos;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login([FromBody] LoginDto login)
        {
            var token = _authService.Autenticar(login);

            if (token == null) {
                return Unauthorized(new
                {
                    mensagem = "E-mail ou senha inválidos. Tente novamnete"
                });
            }


            return Ok(new
            {
                token = token,
                usuarioEmail = login.Email
            });
        }
    }
}
