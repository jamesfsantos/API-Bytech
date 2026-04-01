using ByTech_API.Models;

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
            Categoria = produto.Categoria;
            Descricao = produto.Descricao;
            PrecoVenda = produto.PrecoVenda;
            EstoqueAtual = produto.EstoqueAtual;
            Marca = produto.Marca;
            Imagem = produto.Imagem;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public string Marca { get; set; }
    }
}
