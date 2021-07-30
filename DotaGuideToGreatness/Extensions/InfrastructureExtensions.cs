using DotaGuideToGreatness.BusinessLogic.Interfaces;
using DotaGuideToGreatness.BusinessLogic.Managers;
using DotaGuideToGreatness.DAL;
using DotaGuideToGreatness.DAL.Implementation;
using DotaGuideToGreatness.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Extensions
{
    public static class InfrastructureExtensions
    {

        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddControllers(opts=>
            {

            }).AddNewtonsoftJson(options=> options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotaGuideToGreatness", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DotaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<Func<DotaDbContext>>((provider) => provider.GetService<DotaDbContext>);
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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
            services.AddScoped<IHeroesManager, HeroesManager>();

            return services;
        }
    }
}
