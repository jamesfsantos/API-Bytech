using ByTech_API.Enums;

namespace ByTech_API.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public MetodoPagamento Metodo { get; set; }
        public PagamentoStatus Status { get; set; }
        public DateTime DataConfirmacao { get; set; }
        public PedidoVenda Venda { get; set; }
        
    }
}
