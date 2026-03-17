using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItensVendas>
    {
        public void Configure(EntityTypeBuilder<ItensVendas> builder)
        {
            builder.ToTable("Itens_Venda");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Quantidade).HasColumnName("quantidade");
            builder.Property(x => x.PrecoUnitarioPago).HasColumnName("preco_unitario_pago");

            builder.HasOne(x => x.Venda)
            .WithMany()
            .HasForeignKey(x => x.VendaId);

            builder.HasOne(x => x.Produto)
            .WithMany()
            .HasForeignKey(x => x.ProdutoId);

            builder.Property(x => x.VendaId).HasColumnName("id_venda");
            builder.Property(x => x.ProdutoId).HasColumnName("id_produto");
        }
    }
}
