using Laboratory11;
using Laboratory11.Interfaces;
using Laboratory11.Components;
using Laboratory11.Services;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main()
    {
        var services = new ServiceCollection();

        services.AddServices();


        var provider = services.BuildServiceProvider();
        var console = provider.GetService<IConsoleWrapper>();
        var mediator = provider.GetRequiredService<IMediator>();

        var request = new Request { Message = "I Love, Mediator!" };
        var response = await mediator.Send<Request, string>(request);

        console!.Write($"SEND: {response}");
        var publish = new Message { Content = "This is a notification message." };
        var notificationResult = await mediator.Publish(publish);

        console.Write(
            $"RESULT: Publish Result: Success = {notificationResult.Success}, Message = {notificationResult.Message}");
    }
}
