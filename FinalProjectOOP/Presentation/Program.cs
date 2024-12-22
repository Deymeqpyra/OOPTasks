using Application;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("E:\\Projects\\OOPTasks\\FinalProjectOOP\\Presentation\\appsettings.json", optional: false, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        services.AddApplication();
        
        services.AddInfrastructure(configuration);

        services.AddTransient<ConsoleApp>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var app = scope.ServiceProvider.GetRequiredService<ConsoleApp>();

await app.RunAsync();