using Domain.Integracao.AtualizacoesRelacionamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class AtualizacaoRelacionamentoConfiguration : IEntityTypeConfiguration<AtualizacaoRelacionamento>
    {
        public void Configure(EntityTypeBuilder<AtualizacaoRelacionamento> builder)
        {
            builder.ToTable("AtualizacoesRelacionamentos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.NumeroRemessa).IsRequired();
            builder.Property(e => e.QuantidadeOperacao).IsRequired();
            builder.Property(e => e.DataMovimentacao).HasColumnType("datetime2").IsRequired();
            builder.Property(e => e.DataCriacao).HasColumnType("datetime2");
            builder.Property(e => e.DataAtualizacao).HasColumnType("datetime2").IsRequired(false);
            builder.HasMany(e => e.Clientes);
        }
    }
}
