using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class PedidoVendaDto
    {
        public PedidoVendaDto()
        {
            
        }
        public PedidoVendaDto(PedidoVenda pedidoVenda)
        {
            Id = pedidoVenda.Id;
            UsuarioId = pedidoVenda.UsuarioId;
            DataPedido = pedidoVenda.DataPedido;
            ValorTotalPedido = pedidoVenda.ValorTotalPedido;
            Usuario = pedidoVenda.Usuario;
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotalPedido { get; set; }

        public Usuario Usuario { get; set; }
    }
}
