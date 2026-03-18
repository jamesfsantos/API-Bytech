using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class PedidoVendaConfiguration : IEntityTypeConfiguration<PedidoVenda>
    {
        public void Configure(EntityTypeBuilder<PedidoVenda> builder)
        {
            builder.ToTable("Pedido_Venda");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.DataPedido).HasColumnName("data_pedido");
            builder.Property(x => x.ValorTotalPedido).HasColumnName("valor_total_pedido");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.UsuarioId).HasColumnName("id_usuario");
        }
    }
}
