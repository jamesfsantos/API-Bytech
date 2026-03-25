using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemVendaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IItemVendaService _service;

        public ItemVendaController(AppDbContext context, IItemVendaService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarItemVendas()
        {
            var itens = await _service.ObterTodos();
            if (itens == null)
                return NotFound();
            return Ok(itens);
        }
    }
}
