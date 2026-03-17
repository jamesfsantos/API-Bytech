using ByTech_API.Enums;
using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class PagamentoDto
    {
        public PagamentoDto()
        {
            
        }

        public PagamentoDto(Pagamento pagamento)
        {
            Id = pagamento.Id;
            VendaId = pagamento.VendaId;
            Metodo = pagamento.Metodo;
            Status = pagamento.Status;
            DataConfirmacao = pagamento.DataConfirmacao;
            Venda = pagamento.Venda;
        }

        public int Id { get; set; }
        public int VendaId { get; set; }
        public MetodoPagamento Metodo { get; set; }
        public PagamentoStatus Status { get; set; }
        public DateTime DataConfirmacao { get; set; }
        public PedidosVenda Venda { get; set; }
    }
}
