using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class ItemVendaDto
    {
        public ItemVendaDto()
        {
            
        }

        public ItemVendaDto(ItemVenda itemvenda)
        {
            Id = itemvenda.Id;
            VendaId = itemvenda.VendaId;
            ProdutoId = itemvenda.ProdutoId;
            Quantidade = itemvenda.Quantidade;
            PrecoUnitarioPago = itemvenda.PrecoUnitarioPago;
            Produto = itemvenda.Produto;
            Venda = itemvenda.Venda;
        }


        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioPago { get; set; }

        public Produtos Produto { get; set; }
        public PedidoVenda Venda { get; set; }
    }
}
