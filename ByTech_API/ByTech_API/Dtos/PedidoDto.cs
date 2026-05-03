using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class PedidoDto
    {
        public PedidoDto()
        {
            
        }
        public PedidoDto(Pedido pedido)
        {
            Id = pedido.Id;
            UsuarioId = pedido.UsuarioId;
            DataPedido = pedido.DataPedido;
            ValorTotalPedido = pedido.ValorTotalPedido;
            NomeUsuario = pedido.NomeUsuario;
            Email = pedido.Email;
            Celular = pedido.Celular;
            Cpf = pedido.Cpf;
            Usuario = pedido.Usuario;
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotalPedido { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }


        public Usuario Usuario { get; set; }
    }
}
