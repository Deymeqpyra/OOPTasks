using Domain.User;

namespace Domain.Guest;

public class Guest : User.User
{
    public DateTime WasCreated { get; }

    private Guest(UserId id, DateTime wasCreated, string name, string role) : base(id, name, role)
    {
        WasCreated = wasCreated;
    }

}