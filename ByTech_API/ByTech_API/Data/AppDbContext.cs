using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using ByTech_API.Models;
using ByTech_API.Data.Configurations;

namespace ByTech_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<PedidosVenda> PedidosVenda { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<ServicoManutencao> ServicosManutencoes { get; set; }
        public DbSet<ItensVendas> ItensVendas { get; set; }
        public DbSet<CampanhaEmail> CampanhasEmails { get; set; }
        public DbSet<MensagensContato> MensagensContatos { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CampanhaEmailConfiguration());

            
            

            modelBuilder.Entity<ItensVendas>(e =>
            {
                e.ToTable("Itens_Venda");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Quantidade).HasColumnName("quantidade");
                e.Property(x => x.PrecoUnitarioPago).HasColumnName("preco_unitario_pago");

                e.HasOne(x => x.Venda)
                .WithMany()
                .HasForeignKey(x => x.VendaId);

                e.HasOne(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.ProdutoId);

                e.Property(x => x.VendaId).HasColumnName("id_venda");
                e.Property(x => x.ProdutoId).HasColumnName("id_produto");
            });

            modelBuilder.Entity<MensagensContato>(e =>
            {
                e.ToTable("Mensagens_Contato");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Nome).HasColumnName("nome_visitante").IsRequired();
                e.Property(x => x.Email).HasColumnName("email").IsRequired();
                e.Property(x => x.Celular).HasColumnName("celular").IsRequired();
                e.Property(x => x.Mensagem).HasColumnName("mensagem").IsRequired();
                e.Property(x => x.Data_Envio).HasColumnName("data_envio");

                e.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

                e.Property(x => x.UsuarioId).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<Pagamentos>(e =>
            {
                e.ToTable("Pagamentos");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Metodo).HasConversion<string>().HasColumnName("metodo");
                e.Property(x => x.Status).HasConversion<string>().HasColumnName("status");
                e.Property(x => x.Data_Confirmacao).HasColumnName("data_confirmacao");

                e.HasOne(x => x.Venda)
                .WithOne()
                .HasForeignKey<Pagamentos>(x => x.VendaId);

                e.Property(x => x.VendaId).HasColumnName("id_venda");
            });

            modelBuilder.Entity<PedidosVenda>(e => {
                e.ToTable("Pedidos_Venda");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Data_Pedido).HasColumnName("data_pedido");
                e.Property(x => x.Valor_Total_Pedido).HasColumnName("valor_total_pedido");

                e.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

                e.Property(x => x.UsuarioId).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<Produtos>(e => {
                e.ToTable("Produtos");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Nome).HasColumnName("nome").IsRequired();
                e.Property(x => x.Descricao).HasColumnName("descricao").IsRequired();
                e.Property(x => x.Preco_Venda).HasColumnName("preco_venda");
                e.Property(x => x.Estoque_Atual).HasColumnName("estoque_atual");
                e.Property(x => x.Marca).HasColumnName("marca").IsRequired();
            });

            modelBuilder.Entity<ServicoManutencao>(e =>
            {
                e.ToTable("Servicos_Manutencao");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Protocolo).HasColumnName("protocolo").IsRequired();
                e.Property(x => x.Equipamento).HasColumnName("equipamento").IsRequired();
                e.Property(x => x.Descricao_Problema).HasColumnName("descricao_problema");
                e.Property(x => x.Observacoes_Tecnicas).HasColumnName("observacoes_tecnicas");
                e.Property(x => x.Status_Servico).HasConversion<string>().HasColumnName("status_servico");
                e.Property(x => x.Data_Entrada).HasColumnName("data_entrada");

                e.HasOne(x => x.Tecnico)
                .WithMany()
                .HasForeignKey(x => x.TecnicoId);

                e.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId);

                e.Property(x => x.TecnicoId).HasColumnName("id_tecnico");
                e.Property(x => x.ClienteId).HasColumnName("id_cliente");
            });

            modelBuilder.Entity<Usuarios>(e =>
            {
                e.ToTable("Usuarios");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Nome).HasColumnName("nome").IsRequired();
                e.Property(x => x.Email).HasColumnName("email").IsRequired();
                e.Property(x => x.Senha).HasColumnName("senha").IsRequired();
                e.Property(x => x.TipoUsuario).HasConversion<string>().HasColumnName("tipo_usuario");
            });

            
        }
    }
}
