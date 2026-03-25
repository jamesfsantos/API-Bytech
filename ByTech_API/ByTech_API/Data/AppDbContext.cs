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
        public DbSet<PedidoVenda> PedidosVenda { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<ServicoManutencao> ServicoManutencoes { get; set; }
        public DbSet<ItemVenda> ItensVendas { get; set; }
        public DbSet<CampanhaEmail> CampanhasEmails { get; set; }
        public DbSet<MensagensContato> MensagensContatos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new CampanhaEmailConfiguration());
            modelBuilder.ApplyConfiguration(new ItemVendaConfiguration());
            modelBuilder.ApplyConfiguration(new MensagemContatoConfiguration());
            modelBuilder.ApplyConfiguration(new PagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoVendaConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ServicoManutencaoConfiguration());            
        }
    }
}
