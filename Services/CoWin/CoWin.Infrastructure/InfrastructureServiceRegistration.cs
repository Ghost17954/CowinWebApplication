using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoWin.Application.Contracts.Persistance;
using CoWin.Infrastructure.Persistance;
using CoWin.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {           
            var temp = configuration.GetConnectionString("VaccinationDbConnectionString");
            Console.WriteLine(temp);
            services.AddDbContext<VaccinationContext>(o => o.UseSqlServer(configuration.GetConnectionString("VaccinationDbConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVaccinationDetailRepository, VaccinationRepository>();

            return services;
        }
    }
}
