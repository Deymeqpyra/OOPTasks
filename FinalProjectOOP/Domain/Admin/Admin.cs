using Domain.User;

namespace Domain.Admin;

public class Admin : User.User
{
    public AdminId Id { get; }
    private string _password;

    public Admin(AdminId id, string password, string adminUserName, string roleType) : base(UserId.New(),
        adminUserName, roleType)
    {
        Id = id;
        _password = password;
    }
}