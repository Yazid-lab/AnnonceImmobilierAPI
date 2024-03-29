﻿using GestionAnnonce.Application.Common.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Infrastructure.Services;
using Infrastructure.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AdManagementContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(AdManagementContext).Assembly.FullName)));
        services.AddScoped<IAdManagementContext>(provider =>
            provider.GetRequiredService<AdManagementContext>());
        services.AddScoped<IAdRepository, AdRepository>();
        services.AddTransient<IEmailSender, EmailSender>();
        //services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}

