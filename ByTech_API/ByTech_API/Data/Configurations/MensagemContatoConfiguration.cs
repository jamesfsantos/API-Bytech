using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class MensagemContatoConfiguration : IEntityTypeConfiguration<MensagensContato>
    {
        public void Configure(EntityTypeBuilder<MensagensContato> builder)
        {
            builder.ToTable("Mensagens_Contato");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome_visitante").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").IsRequired();
            builder.Property(x => x.Celular).HasColumnName("celular").IsRequired();
            builder.Property(x => x.Mensagem).HasColumnName("mensagem").IsRequired();
            builder.Property(x => x.Data_Envio).HasColumnName("data_envio");
            
            builder.HasOne(x => x.Usuario)
            .WithMany()
            .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.UsuarioId).HasColumnName("id_usuario");
        }
    }
}
