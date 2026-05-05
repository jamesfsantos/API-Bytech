using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaEmailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICampanhaEmailService _service;

       public CampanhaEmailController(AppDbContext context, ICampanhaEmailService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarEmails() {
        
        var emails = await _service.ObterTodos();
            if (emails == null)
                return NotFound();
            return Ok(emails);
        }
    }
}
