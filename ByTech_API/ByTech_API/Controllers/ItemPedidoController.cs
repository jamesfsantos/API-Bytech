using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IItemService _service;

        public ItemPedidoController(AppDbContext context, IItemService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarItemPedidos()
        {
            var itens = await _service.ObterTodos();
            if (itens == null)
                return NotFound();
            return Ok(itens);
        }
    }
}
