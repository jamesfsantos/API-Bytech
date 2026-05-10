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
            if (usuario == null) throw new Exception("Usuário nao encontrado para o email fornecido");


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
                StatusPedidoId = 1,
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

        public async Task<bool> AtualizarStatusPedido(int idPedido, int idStatus)
        {
            var pedido = await _context.Pedidos.FindAsync(idPedido);
            var statusPedido = await _context.StatusPedidos.FindAsync(idStatus);

            if (pedido == null || statusPedido == null)
                return false;

            pedido.StatusPedidoId = idStatus;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
                return false;

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoDto> ObterPedidoId(int id)
        {
            var pedido = await _context.Pedidos
                                .Include(p => p.ItensPedidos)
                                .Include(p => p.StatusPedido)
                                .FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null)
                return null;

            return new PedidoDto
            {
                Id = pedido.Id,
                Celular = pedido.Celular,
                Cep = pedido.Cep,
                Cidade = pedido.Cidade,
                Complemento = pedido.Complemento,
                Cpf = pedido.Cpf,
                DataPedido = pedido.DataPedido,
                Email = pedido.Email,
                Endereco = pedido.Endereco,
                NomeUsuario = pedido.NomeUsuario,
                ValorTotalPedido = pedido.ValorTotalPedido,
                Itens = pedido.ItensPedidos.Select(x => new ItemPedidoDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Quantidade = x.Quantidade,
                    Valor = x.Valor,
                    ValorTotal = x.ValorTotal,
                    ProdutoId = x.ProdutoId
                }).ToList(),
                StatusPedido = new StatusPedidoDto { Id = pedido.StatusPedido.Id, StatusAtual = pedido.StatusPedido.StatusAtual },
                StausPedidoId = pedido.StatusPedidoId,
                UsuarioId = pedido.UsuarioId
            };
        }

        public async Task<IEnumerable<ProdutosVendidosDto>> ObterProdutosVendidos()
        {
            var produtos = await _context.Pedidos
                .Where(x => x.StatusPedido.StatusAtual == "Pago")
                .SelectMany(x => x.ItensPedidos)
                .GroupBy(i => i.Nome)
                .Select(g => new ProdutosVendidosDto 
                {
                    NomeProduto = g.Key,
                    Quantidade = g.Sum(i => i.Quantidade),
                })
                .ToListAsync();

            if(produtos.Count == 0)
            {
                return null;
            }

            return produtos;
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidos()
        {
            var pedidos = await _context.Pedidos.Include(p => p.ItensPedidos).Include(p => p.StatusPedido).ToListAsync();

            if (pedidos == null || !pedidos.Any())
                return null;

            return pedidos.Select(pedido => new PedidoDto(pedido));
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidosEmail(string email)
        {
            var pedidos = await _context.Pedidos.Include(p => p.ItensPedidos).Include(p => p.StatusPedido).Where(x => x.Email == email).ToListAsync();

            if (pedidos == null)
                return null;

            return pedidos.Select(pedido => new PedidoDto(pedido));
        }
    }
}
