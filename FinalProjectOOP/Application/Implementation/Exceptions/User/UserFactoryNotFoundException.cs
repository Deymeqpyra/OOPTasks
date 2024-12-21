namespace Application.Implementation.Exceptions.User;

public class UserFactoryNotFoundException : Exception
{
    public UserFactoryNotFoundException()
        : base("The user factory was not found.")
    {
    }
}