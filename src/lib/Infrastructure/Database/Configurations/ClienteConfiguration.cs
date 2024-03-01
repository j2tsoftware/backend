using Domain.Integracao.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => new { e.Documento }).IsUnique();
            builder.Property(e => e.Documento).HasMaxLength(15).IsRequired();
            builder.Property(e => e.Nome).HasMaxLength(500);
            builder.Property(e => e.TipoPessoa).IsRequired();
            builder.Property(e => e.DataInicio).HasColumnType("datetime2");
            builder.Property(e => e.DataFim).HasColumnType("datetime2");
        }
    }
}
