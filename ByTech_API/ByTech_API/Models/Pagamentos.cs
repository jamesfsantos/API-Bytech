namespace ByTech_API.Models
{
    public class Pagamentos
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public MetodoPagamento Metodo { get; set; }
        public PagamentoStatus Status { get; set; }
        public DateTime Data_Confirmacao { get; set; }


        public PedidosVenda Venda { get; set; }
        public enum PagamentoStatus
        {
            Aprovado,
            Recusado,
            Pendente
        }

        public enum MetodoPagamento 
        {
            Pix,
            Cartao,
            Boleto
        }
    }
}
