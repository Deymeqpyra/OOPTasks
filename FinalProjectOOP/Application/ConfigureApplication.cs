using System.Reflection;
using Application.Abstraction.Interfaces;
using Application.Implementation.Factory;
using Application.Implementation.Manager;
using Application.Implementation.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureApplication
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton<IUserManager, UserManager>();
        services.AddSingleton<ILogger>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var factory = LoggerFactoryProvider.GetFactory(configuration);
            return factory.CreateLogger();
        });
    }
}