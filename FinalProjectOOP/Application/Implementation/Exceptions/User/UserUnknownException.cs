namespace Application.Implementation.Exceptions.User;

public class UserUnknownException : Exception
{
    public UserUnknownException() : base("Unknown exception while creating user")
    {
        
    }
}