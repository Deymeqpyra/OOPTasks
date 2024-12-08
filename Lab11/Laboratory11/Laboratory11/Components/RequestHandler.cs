using Laboratory11.Interfaces;

namespace Laboratory11.Components;

public class RequestHandler : IRequestHandler<Request, string>
{
    public Task<string> Handle(Request request)
    {
        return Task.FromResult($"Handled Request: {request.Message}");
    }
}