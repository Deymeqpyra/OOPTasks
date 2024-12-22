namespace Application.Implementation.Exceptions.User;

public class UserNameIsEmpty : Exception
{
    public UserNameIsEmpty() : base("User name is empty.")
    {
        
    }
}