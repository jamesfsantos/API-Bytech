using ByTech_API.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterCategorias()
        {
            var categorias = await _categoriaService.ObterTodosAsync();
            if(categorias == null)
                return NotFound();
            return Ok(categorias);
        }
    }
}
