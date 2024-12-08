namespace Laboratory11.Interfaces
{
    public interface IPublisher
    {
        Task<HandleResult> Publish<TMessage>(TMessage message) where TMessage : IMessage;
    }
}