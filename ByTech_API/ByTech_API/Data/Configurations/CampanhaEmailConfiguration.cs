using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class CampanhaEmailConfiguration : IEntityTypeConfiguration<CampanhaEmail>
    {
        public void Configure(EntityTypeBuilder<CampanhaEmail> builder)
        {
            builder.ToTable("Campanhas_Email");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Assunto).HasColumnName("assunto").IsRequired();
            builder.Property(x => x.CorpoMensagem).HasColumnName("corpo_mensagem").IsRequired();
            builder.Property(x => x.Data_Disparo).HasColumnName("data_disparo");

            builder.HasOne(x => x.UsuarioAdmin)
                .WithMany()
                .HasForeignKey(x => x.AdminId);

            builder.Property(x => x.AdminId).HasColumnName("id_admin");

        }
    }
}
