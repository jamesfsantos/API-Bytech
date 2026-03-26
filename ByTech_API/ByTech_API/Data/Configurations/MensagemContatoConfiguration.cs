using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class MensagemContatoConfiguration : IEntityTypeConfiguration<MensagensContato>
    {
        public void Configure(EntityTypeBuilder<MensagensContato> builder)
        {
            builder.ToTable("Mensagem_Contato");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome_visitante").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.Celular).HasColumnName("celular").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Mensagem).HasColumnName("mensagem").HasColumnType("text").IsRequired();
            builder.Property(x => x.Data_Envio).HasColumnName("data_envio").IsRequired();
            
            builder.HasOne(x => x.Usuario)
            .WithMany()
            .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.UsuarioId).HasColumnName("id_usuario");
        }
    }
}
