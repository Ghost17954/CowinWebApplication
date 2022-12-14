using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace CoWin.API.Extentions
{
    public static class HostExtention
    {
        
        public static IHost MigrateDatabse<TContext>(this IHost host,Action<TContext,IServiceProvider> seeder,int? retry = 0)where TContext : DbContext
        {
            int retryForAvailability = retry.Value;

            using(var scope = host.Services.CreateScope())
            {
                var services=scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                var temp = config.GetConnectionString("VaccinationDbConnectionString");
                var logger=services.GetRequiredService<ILogger<TContext>>();
                var context=services.GetRequiredService<TContext>();

                try
                {
                    logger.LogInformation("ConnectionString {ConectionString}", temp);
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                    InvokeSeeder(seeder, context, services);

                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);

                }
                catch (SqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabse<TContext>(host, seeder, retryForAvailability);
                    }                    
                }
            }

            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext : DbContext
        {
           context.Database.Migrate();
            seeder(context, services);
        }
    }
}
