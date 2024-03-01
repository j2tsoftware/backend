using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Database
{
    public static class DatabaseInitialitizer
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (!string.IsNullOrEmpty(environment))
            {
                bool isDevelopment = environment.Equals(Environments.Development);

                if (isDevelopment)
                {
                    var db = services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
                    db.Database.Migrate();
                }
            }

            return services;
        }
    }
}
