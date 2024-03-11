using Domain.Gerenciamento.Usuarios;
using Domain.Integracao.Clientes;
using Domain.Shared.Repositories;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AdicionarInfraestrutura(this IServiceCollection services)
        {
            services.RegisterContextoDoBancoDeDados();
            services.RegistrarRepositorios();

            return services;
        }

        private static IServiceCollection RegisterContextoDoBancoDeDados(this IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(services), "Conexão com banco não informada");

            services.AddDbContext<DatabaseContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString, s => s.EnableRetryOnFailure(1));
            });

            return services;
        }

        private static IServiceCollection RegistrarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
