using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Services;
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
        

        [HttpGet("email/{email}")]
        public async Task<IActionResult> ObterPedidosEmail(string email)
        {
            var pedidos = await _service.ObterTodosPedidosEmail(email);
            if (pedidos == null)
                return NotFound($"Erro ao obter pedidos pelo email: {email}");

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedidoId(int id)
        {
            var pedido = await _service.ObterPedidoId(id);
            if (pedido == null)
                return NotFound();
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPedido(int id)
        {
            var pedido = await _service.ExcluirPedido(id);
            if(pedido == false)
                return NotFound();
            return Ok(pedido);
        }
        [HttpPatch("{id}/status/{idStatus}")]
        public async Task<IActionResult> AlterarStatus(int id, int idStatus)
        {
            var sucesso = await _service.AtualizarStatusPedido(id, idStatus);

            if (!sucesso)
                return BadRequest("Pedido ou Status não localizado.");

            return Ok(new { message = "Status atualizado!" });
        }
    }
}
