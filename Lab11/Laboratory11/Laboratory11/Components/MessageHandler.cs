using Laboratory11.Interfaces;
using Laboratory11.Services;

namespace Laboratory11.Components;

public class MessageHandler : IRequestHandler<Message, HandleResult>
{
    private IConsoleWrapper _consoleWrapper;

    public MessageHandler(IConsoleWrapper consoleWrapper)
    {
        _consoleWrapper = consoleWrapper;
    }
    public Task<HandleResult> Handle(Message message)
    {
        _consoleWrapper.Write($"PUBLISHED: {message.Content}");

        return Task.FromResult(new HandleResult(true, "Message handled successfully."));
    }
}
