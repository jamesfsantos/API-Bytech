using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Senha).HasColumnName("senha").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.SenhaSalt).HasColumnName("senhaSalt").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.Celular).HasColumnName("celular").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.TipoUsuarioId).HasColumnName("id_tipo_usuario").HasColumnType("int(11)").IsRequired();

            builder.HasOne(x => x.TipoUsuario)
                    .WithMany()
                    .HasForeignKey(x => x.TipoUsuarioId);

        }
    }
}
