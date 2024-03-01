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
                ArgumentNullException.ThrowIfNull(nameof(connectionString));
            else 
                services.AddDbContext<DatabaseContext>(optionsBuilder => { optionsBuilder.UseSqlServer(connectionString); });

            return services;
        }

        private static IServiceCollection RegistrarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork>(x => new UnitOfWork(x.GetRequiredService<DatabaseContext>()));
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IClientesRepositorio, ClientesRepositorio>();

            return services;
        }
    }
}
