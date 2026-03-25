using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemContatoController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IMensagensContatoService _service;

        public MensagemContatoController(AppDbContext context, IMensagensContatoService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> BuscarMensagem()
        {
            var mensagens = await _service.ObterTodos();
            if (mensagens == null)
                return NotFound();
            return Ok(mensagens);
        }
    }
}
