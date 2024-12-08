using Laboratory11.Interfaces;
using Laboratory11.Components;
using Laboratory11.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Laboratory11
{
    public static class IoCContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, Mediator>();
            services.AddTransient<ISender, Mediator>();
            services.AddTransient<IPublisher, Mediator>();
            
            services.AddTransient<IRequestHandler<Request, string>, RequestHandler>();
            services.AddTransient<IRequestHandler<Message, HandleResult>, MessageHandler>();

            services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
        }
    }
}