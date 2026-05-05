using ByTech_API.Models;
using System.Text.Json.Serialization;

namespace ByTech_API.Dtos
{
    public class ProdutoDto
    {
        public ProdutoDto()
        {}
        public ProdutoDto(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            CategoriaId = produto.CategoriaId;
            Descricao = produto.Descricao;
            PrecoVenda = produto.PrecoVenda;
            EstoqueAtual = produto.EstoqueAtual;
            Marca = produto.Marca;
            Imagem = produto.Imagem;
            DataCadastro = produto.DataCadastro;
            DataAtualizacao = produto.DataAtualizacao;
            Ativo = produto.Ativo;
            Categoria = new CategoriaDto
            {
                Id = produto.Categoria.Id,
                Nome = produto.Categoria.Nome
            };
        }

        
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public string Marca { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public CategoriaDto? Categoria { get; set; }
    }
}
