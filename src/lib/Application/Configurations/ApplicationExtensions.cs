using Application.Handlers.Clientes;
using Domain.Integracao.Clientes;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AdicionarAplicacao(this IServiceCollection services)
        {
            services.RegistrarHandlers();

            return services;
        }

        public static IServiceCollection RegistrarHandlers(this IServiceCollection services)
        {
            services.AddScoped<IAdicionarClienteHandler, AdicionarClienteHandler>();

            return services;
        }

    }
}
