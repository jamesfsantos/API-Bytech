using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context, IProdutoService service)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutos() 
        {
            var produtos = await _service.ObterTodosAsync();
            if(produtos == null)
                return NotFound();
            return Ok(produtos);
        }
    }
}
