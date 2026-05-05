using ByTech_API.Dtos;
using ByTech_API.Models;

namespace ByTech_API.Extensions
{
    public static class ProdutoExtensions
    {
        public static void AtualizaParaProdutoDto(this Produto produto, ProdutoDto produtoDto)
        {
            
            if (!string.IsNullOrEmpty(produtoDto.Nome) && produtoDto.Nome != "string")
                produto.Nome = produtoDto.Nome;

            if (!string.IsNullOrEmpty(produtoDto.Imagem) && produtoDto.Imagem != "string")
                produto.Imagem = produtoDto.Imagem;

            if (!string.IsNullOrEmpty(produtoDto.Descricao) && produtoDto.Descricao != "string")
                produto.Descricao = produtoDto.Descricao;

            if (!string.IsNullOrEmpty(produtoDto.Marca) && produtoDto.Marca != "string")
                produto.Marca = produtoDto.Marca;

            
            if (produtoDto.PrecoVenda > 0)
                produto.PrecoVenda = produtoDto.PrecoVenda;

            if (produtoDto.CategoriaId > 0)
                produto.CategoriaId = produtoDto.CategoriaId;

            if (produtoDto.EstoqueAtual >= 0) 
                produto.EstoqueAtual = produtoDto.EstoqueAtual;

            

        }

    }
}
