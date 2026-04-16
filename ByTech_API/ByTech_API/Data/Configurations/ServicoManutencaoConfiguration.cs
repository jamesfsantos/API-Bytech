using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class ServicoManutencaoConfiguration : IEntityTypeConfiguration<ServicoManutencao>
    {
        public void Configure(EntityTypeBuilder<ServicoManutencao> builder)
        {
            builder.ToTable("servico_manutencao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Protocolo).HasColumnName("protocolo").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Equipamento).HasColumnName("equipamento").IsRequired();
            builder.Property(x => x.Descricao_Problema).HasColumnName("descricao_problema");
            builder.Property(x => x.Observacoes_Tecnicas).HasColumnName("observacoes_tecnicas");
            builder.Property(x => x.Status_Servico).HasConversion<string>().HasColumnName("status_servico");
            builder.Property(x => x.Data_Entrada).HasColumnName("data_entrada").IsRequired();
            builder.Property(x => x.TecnicoId).HasColumnName("id_tecnico");
            builder.Property(x => x.ClienteId).HasColumnName("id_cliente");

            builder.HasOne(x => x.Tecnico)
            .WithMany()
            .HasForeignKey(x => x.TecnicoId);

            builder.HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey(x => x.ClienteId);

            
        }
    }
}
