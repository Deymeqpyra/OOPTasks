namespace Application.Implementation.Exceptions.User;

public class NoUsersFoundException : Exception
{
    public NoUsersFoundException() : base("No users found.")
    {
        
    }
}