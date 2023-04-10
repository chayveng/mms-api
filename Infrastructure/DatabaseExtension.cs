using Microsoft.EntityFrameworkCore;
using mms_api.Infrastucture;

namespace mms_api.Infrastructure
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LocalDatabase"));
                if (!env.IsProduction())
                {
                    options.EnableDetailedErrors();
                    // options.EnableSensitiveDataLogging();
                }
            });
            return services;
        }

    }
}