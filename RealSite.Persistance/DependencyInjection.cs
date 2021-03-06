using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace RealSite.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DefaultConnection"];

            services.AddDbContext<RealSiteDbContext>(options =>
                    options.UseSqlServer(connectionString));

            //services.AddScoped<INotesDbContext>(provider =>
            //   provider.GetService<RealSiteDbContext>());
            return services;
        }
    }
}
