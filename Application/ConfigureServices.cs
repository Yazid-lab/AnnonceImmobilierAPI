using System.Reflection;
using FluentValidation;
using GestionAnnonce.Application.Common.Interfaces;
using GestionAnnonce.Application.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IAdService, AdService>();
        //services.AddScoped<IUserService, UserService>();
        return services;
    }

}

