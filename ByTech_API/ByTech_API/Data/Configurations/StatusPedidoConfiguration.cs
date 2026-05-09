using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class StatusPedidoConfiguration : IEntityTypeConfiguration<StatusPedido>
    {
        public void Configure(EntityTypeBuilder<StatusPedido> builder)
        {
            builder.ToTable("status_pedido");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.StatusAtual).HasColumnName("status_atual");
        }
    }
}
