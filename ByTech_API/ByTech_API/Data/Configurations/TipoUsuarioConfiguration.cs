using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("tipo_usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int(11)").HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)");
        }
    }
}
