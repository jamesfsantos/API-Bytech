using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ByTech_API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProdutoDto> AdicionarProduto(ProdutoDto produtoDto)
        {
            var produto = new Produto 
            {
                Nome = produtoDto.Nome,
                Marca = produtoDto.Marca,
                Categoria = produtoDto.Categoria,
                Descricao = produtoDto.Descricao,
                EstoqueAtual = produtoDto.EstoqueAtual,
                PrecoVenda = produtoDto.PrecoVenda,
                Imagem = produtoDto.Imagem,
            };

            _context.Add(produto);
            await _context.SaveChangesAsync();
            produtoDto.Id = produto.Id;
            return produtoDto;
        }

        public async Task<List<ProdutoDto>> ObterPorCategoria(string categoria)
        {
            var produto = await _context.Produtos.Where(c => c.Categoria == categoria).ToListAsync();
            if (produto == null)
                return null;

            var produtoDto = produto.Select(p => new ProdutoDto{
                Id = p.Id,
                Nome = p.Nome,
                Marca = p.Marca,
                Categoria = p.Categoria,
                Descricao = p.Descricao,
                EstoqueAtual = p.EstoqueAtual,
                PrecoVenda = p.PrecoVenda,
                Imagem = p.Imagem
            }).ToList();

            return produtoDto;
        }

        public async Task<ProdutoDto> ObterPorId(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return null;

            return new ProdutoDto {
                Id = produto.Id,
                Nome = produto.Nome,
                Marca = produto.Marca,
                Categoria = produto.Categoria,
                Descricao = produto.Descricao,
                EstoqueAtual = produto.EstoqueAtual,
                PrecoVenda = produto.PrecoVenda,
                Imagem = produto.Imagem
            };
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodosAsync()
        {
            var produtos = await _context.Produtos.ToListAsync();
            if (produtos == null || !produtos.Any())
                return null;
            return produtos.Select(produto => new ProdutoDto(produto));
        }
    }
}
