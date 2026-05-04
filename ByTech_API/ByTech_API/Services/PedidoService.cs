using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;
        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PedidoDto> AdicionarPedido(PedidoDto pedidoDto)
        {
            var pedido = new Pedido
            {
                UsuarioId = pedidoDto.UsuarioId,
                NomeUsuario = pedidoDto.NomeUsuario,
                Email = pedidoDto.Email,
                Celular = pedidoDto.Celular,
                Cpf = pedidoDto.Cpf,
                DataPedido = DateTime.Now,
                ValorTotalPedido = pedidoDto.ValorTotalPedido,
                ItensPedidos = pedidoDto.Itens.Select(itemDto => new ItemPedido
                {
                    ProdutoId = itemDto.ProdutoId,
                    Nome = itemDto.Nome,
                    Quantidade = itemDto.Quantidade,
                    Valor = itemDto.Valor,
                    ValorTotal = itemDto.ValorTotal,
                }).ToList()
            };
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == pedidoDto.UsuarioId);
            if (!usuarioExiste)
                throw new Exception($"Erro: Usuario com ID{pedidoDto.UsuarioId} não existe");
            _context.Pedidos.Add(pedido);


            await _context.SaveChangesAsync();
            return pedidoDto;
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidos()
        {
            var pedidos = await _context.Pedidos.ToListAsync();

            if (pedidos == null || !pedidos.Any())
                return null;

            return pedidos.Select(pedido => new PedidoDto(pedido));
        }
    }
}
