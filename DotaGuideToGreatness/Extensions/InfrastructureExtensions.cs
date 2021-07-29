using DotaGuideToGreatness.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DotaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
            });

            services.AddScoped<Func<DotaDbContext>>((provider) => provider.GetService<DotaDbContext>);

            return services;
        }
    }
}
