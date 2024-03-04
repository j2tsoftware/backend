using Domain.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Database
{
    public static class DatabaseInitialitizer
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services)
        {
            try
            {
                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (!string.IsNullOrEmpty(environment))
                {
                    bool isDevelopment = environment.Equals(Environments.Development);

                    if (isDevelopment)
                    {
                        var context = services.BuildServiceProvider().GetRequiredService<DatabaseContext>();

                        if (context.Database.GetPendingMigrations().Any())
                            context.Database.Migrate();
                        else
                            context.Database.EnsureCreated();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inicializar banco de dados: {ex.Message}");
            }

            return services;
        }
    }
}
