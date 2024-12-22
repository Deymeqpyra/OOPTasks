namespace Application.Implementation.Exceptions.User;

public class EmptyCrenditalsException : Exception
{
    public EmptyCrenditalsException() : base("Empty credentials not allowed!")
    {
        
    }
}