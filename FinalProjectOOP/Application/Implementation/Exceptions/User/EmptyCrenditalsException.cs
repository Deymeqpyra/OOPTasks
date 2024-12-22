namespace Application.Implementation.Exceptions.User;

public class EmptyCrenditalsException : Exception
{
    public EmptyCrenditalsException() : base("Empty crenditals not allowed!")
    {
        
    }
}