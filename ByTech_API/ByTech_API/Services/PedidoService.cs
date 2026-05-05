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
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == pedidoDto.Email);
            if (usuario == null) throw new Exception("Usuário nao encontrado para o email fornecido") ;


            var pedido = new Pedido
            {
                UsuarioId = usuario.Id,
                NomeUsuario = pedidoDto.NomeUsuario,
                Email = pedidoDto.Email,
                Celular = pedidoDto.Celular,
                Cpf = pedidoDto.Cpf,
                DataPedido = DateTime.Now,
                ValorTotalPedido = pedidoDto.ValorTotalPedido,
                Endereco = pedidoDto.Endereco,
                Cep= pedidoDto.Cep,
                Cidade = pedidoDto.Cidade,
                Complemento = pedidoDto.Complemento,
                ItensPedidos = pedidoDto.Itens.Select(itemDto => new ItemPedido
                {
                    ProdutoId = itemDto.ProdutoId,
                    Nome = itemDto.Nome,
                    Quantidade = itemDto.Quantidade,
                    Valor = itemDto.Valor,
                    ValorTotal = itemDto.ValorTotal,
                }).ToList()
            };
            //var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == pedidoDto.UsuarioId);
            //if (!usuarioExiste)
            //    throw new Exception($"Erro: Usuario com ID{pedidoDto.UsuarioId} não existe");
            _context.Pedidos.Add(pedido);


            await _context.SaveChangesAsync();
            return pedidoDto;
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidos()
        {
            var pedidos = await _context.Pedidos.Include(p => p.ItensPedidos).ToListAsync();

            if (pedidos == null || !pedidos.Any())
                return null;

            return pedidos.Select(pedido => new PedidoDto(pedido));
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidosEmail(string email)
        {
            var pedidos = await _context.Pedidos.Include(p => p.ItensPedidos).Where(x => x.Email == email).ToListAsync();

            if (pedidos == null)
                return null;

            return pedidos.Select(pedido => new PedidoDto(pedido));
        }
    }
}
