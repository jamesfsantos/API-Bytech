using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("item_pedido");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasColumnType("INT(11)").IsRequired();
            builder.Property(x => x.Valor).HasColumnName("valor").IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("valor_total").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome_produto").IsRequired();
            builder.Property(x => x.PedidoId).HasColumnName("id_pedido").IsRequired();
            builder.Property(x => x.ProdutoId).HasColumnName("id_produto").IsRequired();


            builder.HasOne(x => x.Pedido)
            .WithMany()
            .HasForeignKey(x => x.PedidoId);

            builder.HasOne(x => x.Produto)
            .WithMany()
            .HasForeignKey(x => x.ProdutoId);

            
        }
    }
}
