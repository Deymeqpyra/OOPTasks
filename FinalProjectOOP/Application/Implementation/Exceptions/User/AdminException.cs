namespace Application.Implementation.Exceptions.User;

public class AdminException : Exception
{
    public AdminException(string message)
        : base(message){}
}