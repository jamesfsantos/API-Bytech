using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly AppDbContext _context;
        public PagamentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagamentoDto> ObterPagamentoId(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);

            if (pagamento == null)
                return null;

            return new PagamentoDto
            {
                Id = pagamento.Id,
                VendaId = pagamento.PedidoId,
                DataConfirmacao = pagamento.DataConfirmacao,
                Metodo = pagamento.Metodo,
                Status = pagamento.Status
            };
        }

        public async Task<IEnumerable<PagamentoDto>> ObterTodos()
        {
            var pagamentos = await _context.Pagamentos.ToListAsync();

            if (pagamentos == null || !pagamentos.Any())
                return null;

            return pagamentos.Select(pagamento => new PagamentoDto(pagamento));
        }   
    }
}
