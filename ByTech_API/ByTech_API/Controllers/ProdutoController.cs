using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
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

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDto produtoDto)
        {
            var produto = await _service.AdicionarProduto(produtoDto);

            if (produto == null) return BadRequest();

            return CreatedAtAction(nameof(ObterProdutoId), new { id = produto.Id }, produto);
        }


        [HttpGet]
        public async Task<IActionResult> ObterProdutos() 
        {
            var produtos = await _service.ObterTodosAsync();
            if(produtos == null)
                return NotFound();
            return Ok(produtos);
        }

        [HttpGet("{categoriaId}")]
        public async Task<IActionResult> ObterProdutoId(int categoriaId)
        {
            var produto = await _service.ObterPorIdCategoria(categoriaId);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        //[HttpGet("/api/Produto/Categoria/{categoria}")]
        //public async Task<IActionResult> ObterPorCategoria(string categoria)
        //{
        //    var produto = await _service.ObterPorCategoria(categoria);
        //    if (produto == null)
        //        return NotFound();
        //    return Ok(produto);
        //}
    }
}
