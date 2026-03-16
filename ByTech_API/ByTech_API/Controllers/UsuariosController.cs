using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using ByTech_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUsuariosService _service;

        public UsuariosController(AppDbContext context, IUsuariosService service)
        {
            _context = context;
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _service.ObterTodos();
            if(usuarios == null)
                return NotFound();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarUsuarioid(int id)
        {
            
            var usuario = await _service.ObterPorId(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null) return BadRequest();

            var usuario = await _service.AdicionarUsuario(usuarioDto);

            
            return CreatedAtAction(nameof(BuscarUsuarioid), new { id = usuario.Id }, usuario);
        }

        

        [HttpPut("{id}")] 
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest("O Id não corresponde ao do corpo.");
            }
            var usuario = await _service.AtualizarUsuario(id, usuarioDto);         
            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não foi encontrado.");
            }                        
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {

            var excluiu = await _service.ExcluirUsuario(id);
            if (!excluiu)
            {
                return NotFound($"Usuário com {id} não encontrado");
            }

            return NoContent();
        }

        
    }
}
