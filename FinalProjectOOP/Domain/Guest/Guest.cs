using Domain.User;

namespace Domain.Guest;

public class Guest : User.User
{
    public GuestId Id { get; private set; } 
    public DateTime WasCreated { get; }

    private Guest(DateTime wasCreated, string name, string roleName) : base(UserId.New(), name, roleName)
    {
        Id = GuestId.New();
        WasCreated = wasCreated;
    }

}