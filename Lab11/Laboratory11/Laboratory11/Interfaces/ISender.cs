namespace Laboratory11.Interfaces;

public interface ISender
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request) where TRequest : IRequest;
}