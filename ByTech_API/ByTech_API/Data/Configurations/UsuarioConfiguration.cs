using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Senha).HasColumnName("senha").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.TipoUsuario).HasConversion<string>().HasColumnName("tipo_usuario");
        }
    }
}
