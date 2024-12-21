using Domain.User;

namespace Domain.Admin;

public class Admin : User.User
{
    private string _password;

    public Admin(UserId id, string password, string adminUserName, string roleType) : base(id,
        adminUserName, roleType)
    {
        _password = password;
    }
}