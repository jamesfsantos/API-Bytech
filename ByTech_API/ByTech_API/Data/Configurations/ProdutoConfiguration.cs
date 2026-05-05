using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.CategoriaId).HasColumnName("id_categoria").HasColumnType("int(11)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").IsRequired();
            builder.Property(x => x.PrecoVenda).HasColumnName("preco_venda").IsRequired();
            builder.Property(x => x.EstoqueAtual).HasColumnName("estoque_atual").IsRequired();
            builder.Property(x => x.Marca).HasColumnName("marca").IsRequired();
            builder.Property(x => x.Imagem).HasColumnName("imagem").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataAtualizacao).HasColumnName("data_atualizacao").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Ativo).HasColumnType("tinyint").HasColumnName("ativo").IsRequired();

            builder.HasOne(x => x.Categoria)
                    .WithMany()
                    .HasForeignKey(x => x.CategoriaId);
        }
    }
}
