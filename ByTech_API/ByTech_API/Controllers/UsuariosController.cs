using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Models;
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
        public async Task<IActionResult> GetUsuarios()
        {
            //var usuarios = await _service.ObterTodos();
            var usuarios = await _service.ObterTodos();
            return Ok(usuarios);
        }



        [HttpPost]
        public async Task<ActionResult<IEnumerable<Usuarios>>> PostUsuario(Usuarios usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Created(nameof(GetUsuarios), new { id = usuario.Id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {                
                return NotFound($"Usuário com o ID {id} não foi encontrado.");
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> PutUsuario(int id, Usuarios usuario)
        {
            if(id != usuario.Id)
            {
                return BadRequest("O Id informado, é difirente do Id do corpo...");
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            
            var usuario = await _context.Usuarios.FindAsync(id);

            
            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }

            
            _context.Usuarios.Remove(usuario);

            
            await _context.SaveChangesAsync();

            
            return NoContent();
        }

        private bool UsuarioExiste(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
