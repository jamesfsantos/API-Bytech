using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.ToTable("Produto");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").IsRequired();
            builder.Property(x => x.Preco_Venda).HasColumnName("preco_venda");
            builder.Property(x => x.Estoque_Atual).HasColumnName("estoque_atual");
            builder.Property(x => x.Marca).HasColumnName("marca").IsRequired();
        }
    }
}
