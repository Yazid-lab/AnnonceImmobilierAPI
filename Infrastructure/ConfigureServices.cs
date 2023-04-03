using GestionAnnonce.Application.Common.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Infrastructure.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GestionAnnonceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(GestionAnnonceContext).Assembly.FullName)));
            services.AddScoped<IGestionAnnonceContext>(provider =>
                provider.GetRequiredService<GestionAnnonceContext>());
            services.AddScoped<IAnnonceRepository, AnnonceRepository>();

        return services;
        }
    }

