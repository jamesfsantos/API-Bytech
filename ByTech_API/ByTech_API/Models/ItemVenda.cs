namespace ByTech_API.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioPago { get; set; }

        public Produto Produto { get; set; }
        public PedidoVenda Venda { get; set; }
    }
}
