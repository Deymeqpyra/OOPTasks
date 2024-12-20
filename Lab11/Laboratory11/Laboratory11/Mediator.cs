using Laboratory11.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Laboratory11
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest 
        {
            var handler = _serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>();

            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for {typeof(TRequest).Name} not found.");
            }

            return await handler.Handle(request);
        }
        
        public async Task<HandleResult> Publish<TMessage>(TMessage message) 
            where TMessage : IMessage 
        {
            var handlers = _serviceProvider.GetServices<IRequestHandler<TMessage, HandleResult>>();

            HandleResult result = new HandleResult
            {
                Success = true,
                Message = "Notification processed successfully." // status success
            };

            foreach (var handler in handlers)
            {
                try
                {
                    var handlerResult = await handler.Handle(message);
                    result = handlerResult; 
                }
                catch (Exception ex)
                {
                    result = new HandleResult(false, $"Error during publish: {ex.Message}");
                }
            }

            return result;
        }
    }
}