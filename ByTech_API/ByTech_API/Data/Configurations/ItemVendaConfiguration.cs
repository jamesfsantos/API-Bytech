using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("Item_Venda");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasColumnType("INT(11)").IsRequired();
            builder.Property(x => x.PrecoUnitarioPago).HasColumnName("preco_unitario_pago").IsRequired();
            builder.Property(x => x.VendaId).HasColumnName("id_venda").IsRequired();
            builder.Property(x => x.ProdutoId).HasColumnName("id_produto").IsRequired();


            builder.HasOne(x => x.Venda)
            .WithMany()
            .HasForeignKey(x => x.VendaId);

            builder.HasOne(x => x.Produto)
            .WithMany()
            .HasForeignKey(x => x.ProdutoId);

            
        }
    }
}
