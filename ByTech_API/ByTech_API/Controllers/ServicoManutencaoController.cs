using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoManutencaoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IServicoManutencaoService _service;

        public ServicoManutencaoController(AppDbContext context, IServicoManutencaoService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarServicos()
        {
            var servicos = await _service.ObterServicosManutencao();

            if(servicos == null)
                return NotFound();

            return Ok(servicos);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarServico(ServicoManutencaoDto servicoManutencaoDto)
        {
            if(servicoManutencaoDto == null)
                return BadRequest();
            var servico = await _service.AdicionarServicoManutencao(servicoManutencaoDto);
            return CreatedAtAction(nameof(AdicionarServico), new { id = servico.Id }, servico);
        }
    }
}
