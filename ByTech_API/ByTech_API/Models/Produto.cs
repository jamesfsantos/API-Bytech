namespace ByTech_API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public string Marca { get; set; }

        public Categoria Categoria { get; set; }

    }
}
