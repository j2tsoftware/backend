using Domain.Integracao.AtualizacoesRelacionamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class AtualizacaoRelacionamentoClienteConfiguration : IEntityTypeConfiguration<AtualizacaoRelacionamentoCliente>
    {
        public void Configure(EntityTypeBuilder<AtualizacaoRelacionamentoCliente> builder)
        {
            builder.ToTable("AtualizacoesRelacionamentosClientes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Documento).IsRequired();
            builder.Property(e => e.AtualizacaoRelacionamentoId).IsRequired();
            builder.Property(e => e.TipoOperacao).IsRequired();
            builder.Property(e => e.QualificadorOperacao).IsRequired();
        }
    }
}
