namespace ByTech_API.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }
        public string Nome { get; set; }
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
    }
}
