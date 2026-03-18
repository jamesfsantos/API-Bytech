using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PedidoVendaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPedidoVendaService _service;

        public PedidoVendaController(AppDbContext context, IPedidoVendaService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodasVendas()
        {
            var vendas = _service.ObterTodosPedidosVendas();

            if(vendas == null)
                return NotFound();

            return Ok(vendas);
        }
        
    }
}
