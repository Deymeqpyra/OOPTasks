namespace Application.Implementation.Exceptions.User;

public class PasswordIsWeakException : Exception
{
    public PasswordIsWeakException() :  base("Password is weak")
    {
        
    }
}