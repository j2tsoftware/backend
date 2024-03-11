using Domain.Gerenciamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).HasMaxLength(500);
            builder.Property(e => e.Username).HasMaxLength(50);
            builder.Property(e => e.Email).HasMaxLength(100);
        }
    }
}
