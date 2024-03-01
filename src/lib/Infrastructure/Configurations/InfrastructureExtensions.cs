using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.RegisterDatabaseContext();

            return services;
        }

        private static IServiceCollection RegisterDatabaseContext(this IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");

            if (string.IsNullOrEmpty(connectionString))
                ArgumentNullException.ThrowIfNull(nameof(connectionString));
            else 
                services.AddDbContext<DatabaseContext>(optionsBuilder => { optionsBuilder.UseSqlServer(connectionString); });

            return services;
        }
    }
}
