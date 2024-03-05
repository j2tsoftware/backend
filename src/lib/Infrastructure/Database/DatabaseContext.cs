using Domain.Integracao.AtualizacoesRelacionamentos;
using Domain.Integracao.Clientes;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<AtualizacaoRelacionamento> AtualizacoesRelacionamentos { get; set; }
        public DbSet<AtualizacaoRelacionamentoCliente> AtualizacoesRelacionamentosClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new AtualizacaoRelacionamentoConfiguration());
            modelBuilder.ApplyConfiguration(new AtualizacaoRelacionamentoClienteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
