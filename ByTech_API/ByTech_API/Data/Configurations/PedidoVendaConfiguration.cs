using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class PedidoVendaConfiguration : IEntityTypeConfiguration<PedidosVenda>
    {
        public void Configure(EntityTypeBuilder<PedidosVenda> builder)
        {
            builder.ToTable("Pedidos_Venda");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Data_Pedido).HasColumnName("data_pedido");
            builder.Property(x => x.Valor_Total_Pedido).HasColumnName("valor_total_pedido");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.UsuarioId).HasColumnName("id_usuario");
        }
    }
}
