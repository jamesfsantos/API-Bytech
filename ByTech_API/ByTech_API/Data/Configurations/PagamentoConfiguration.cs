using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Metodo).HasConversion<string>().HasColumnName("metodo");
            builder.Property(x => x.Status).HasConversion<string>().HasColumnName("status");
            builder.Property(x => x.DataConfirmacao).HasColumnName("data_confirmacao");
            
            builder.HasOne(x => x.Venda)
            .WithOne()
            .HasForeignKey<Pagamento>(x => x.VendaId);

            builder.Property(x => x.VendaId).HasColumnName("id_venda");
        }
    }
}
