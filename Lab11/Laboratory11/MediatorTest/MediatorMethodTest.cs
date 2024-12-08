using FluentAssertions;
using Laboratory11;
using Laboratory11.Components;
using Laboratory11.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MediatorTest;

public class MediatorMethodTest
{
    private readonly IMediator _mediator;

    public MediatorMethodTest()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IRequestHandler<Request, string>, RequestHandler>()
            .AddTransient<IRequestHandler<Message, HandleResult>, MessageHandler>()
            .AddSingleton<IMediator, Mediator>()
            .BuildServiceProvider();

        _mediator = serviceProvider.GetService<IMediator>()!;
    }

    [Fact]
    public async Task Send_should_return_expected_response_when_handler_exists()
    {
        // Arrange
        var request = new Request { Message = "Hello, Mediator!" };

        // Act
        var result = await _mediator.Send<Request, string>(request);

        // Assert
        result.Should().Be("Handled Request: Hello, Mediator!");
    }

    [Fact]
    public async Task Publish_should_return_success_when_handler_exists()
    {
        // Arrange
        var notification = new Message { Content = "This is a notification message." };

        // Act
        var result = await _mediator.Publish(notification);

        // Assert
        result.Success.Should().BeTrue();
        result.Message.Should().Be("Notification handled successfully.");
    }

    [Fact]
    public async Task Publish_should_handle_multiple_handlers()
    {
        // Arrange
        var notification = new Message { Content = "This is a notification message." };

        var serviceProvider = new ServiceCollection()
            .AddTransient<IRequestHandler<Message, HandleResult>, MessageHandler>()
            .AddSingleton<IMediator, Mediator>()
            .BuildServiceProvider();

        var mediator = serviceProvider.GetService<IMediator>();

        // Act
        var result = await mediator.Publish(notification);

        // Assert
        result.Success.Should().BeTrue();
        result.Message.Should().Be("Notification handled successfully.");
    }

    [Fact]
    public async Task Publish_should_return_error_when_handler_throws_exception()
    {
        // Arrange
        var notification = new Message { Content = "This is a notification message." };

        var serviceProvider = new ServiceCollection()
            .AddTransient<IRequestHandler<Message, HandleResult>>(sp =>
            {
                return new CustomErrorHandler();
            })
            .AddSingleton<IMediator, Mediator>()
            .BuildServiceProvider();

        var mediator = serviceProvider.GetService<IMediator>();

        // Act
        var result = await mediator.Publish(notification);

        // Assert
        result.Success.Should().BeFalse();
        result.Message.Should().Contain("Error during publish: Handler error");
    }

    [Fact]
    public async Task Send_should_return_error_when_handler_not_found()
    {
        // Arrange
        var request = new Request { Message = "Hello, Mediator!" };

        var serviceProvider = new ServiceCollection()
            .AddSingleton<IMediator, Mediator>()
            .BuildServiceProvider();

        var mediator = serviceProvider.GetService<IMediator>();

        // Act
        Func<Task> act = async () => await mediator.Send<Request, string>(request);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Handler for Request not found.");
    }
    
    [Fact]
    public async Task Send_should_handle_multiple_requests_with_same_handler()
    {
        // Arrange
        var request1 = new Request { Message = "First request" };
        var request2 = new Request { Message = "Second request" };

        // Act
        var result1 = await _mediator.Send<Request, string>(request1);
        var result2 = await _mediator.Send<Request, string>(request2);

        // Assert
        result1.Should().Be("Handled Request: First request");
        result2.Should().Be("Handled Request: Second request");
    }

    public class CustomErrorHandler : IRequestHandler<Message, HandleResult>
    {
        public Task<HandleResult> Handle(Message message)
        {
            throw new Exception("Handler error");
        }
    }
}