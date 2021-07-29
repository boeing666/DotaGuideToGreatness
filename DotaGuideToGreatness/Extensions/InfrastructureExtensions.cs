using DotaGuideToGreatness.BusinessLogic.Interfaces;
using DotaGuideToGreatness.BusinessLogic.Managers;
using DotaGuideToGreatness.DAL;
using DotaGuideToGreatness.DAL.Implementation;
using DotaGuideToGreatness.DAL.Interfaces;
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


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IItemsManager, ItemsManager>();

            return services;
        }
    }
}
