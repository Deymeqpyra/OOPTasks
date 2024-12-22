using Domain.User;

namespace Application.Implementation.Exceptions.User;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(UserId userId) : base($"User with {userId.Value} not found"){}
}