using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPedidoService _service;

        public PedidoController(AppDbContext context, IPedidoService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosPedidos()
        {
            var vendas = await _service.ObterTodosPedidos();

            if(vendas == null)
                return NotFound();

            return Ok(vendas);
        }
        
    }
}
