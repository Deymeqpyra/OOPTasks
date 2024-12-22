using Domain.User;

namespace Domain.Guest;

public class Guest : User.User
{
    public DateTime WasCreated { get; }

    private Guest(UserId id, DateTime wasCreated, string name, string role) : base(id, name, role)
    {
        WasCreated = wasCreated;
    }
    public static Guest Create(UserId id, DateTime dateCreated, string name, string role)
        => new(id, dateCreated, name, role);
}