using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class ItemPedidoDto
    {
        public ItemPedidoDto()
        {
            
        }

        public ItemPedidoDto(ItemPedido itemPedido)
        {
            Id = itemPedido.Id;
            PedidoId = itemPedido.PedidoId;
            ProdutoId = itemPedido.ProdutoId;
            Quantidade = itemPedido.Quantidade;
            Valor = itemPedido.Valor;
            ValorTotal = itemPedido.ValorTotal;
            Nome = itemPedido.Nome;
            Produto = itemPedido.Produto;
            Pedido = itemPedido.Pedido;
        }


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
