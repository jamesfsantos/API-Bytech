using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.Categoria).HasColumnName("categoria").IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").IsRequired();
            builder.Property(x => x.PrecoVenda).HasColumnName("preco_venda").IsRequired();
            builder.Property(x => x.EstoqueAtual).HasColumnName("estoque_atual").IsRequired();
            builder.Property(x => x.Marca).HasColumnName("marca").IsRequired();
        }
    }
}
