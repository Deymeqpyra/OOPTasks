namespace Application.Implementation.Exceptions.User;

public class GuestException : Exception
{
    public GuestException(string message)
        : base(message){}
}