using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        
        private readonly IPedidoService _service;

        public PedidoController( IPedidoService service)
        { 
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosPedidos()
        {
            var pedidos = await _service.ObterTodosPedidos();

            if(pedidos == null)
                return NotFound();

            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPedido(PedidoDto pedidoDto)
        {
            var pedidos = await _service.AdicionarPedido(pedidoDto);
            if (pedidos == null)
                return BadRequest("Erro ao adicionar pedido!");

            return Ok(pedidos);
        }
        
    }
}
