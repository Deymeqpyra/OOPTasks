using Domain.User;

namespace Domain.Admin;

public class Admin : User.User
{
    public string Password { get; private set; }

    private Admin(UserId id, string password, string name, string role) : base(id,
        name, role)
    {
        Password = password;
    }
    
    public static Admin Create(UserId id, string password, string name, string role)
    => new Admin(id, password, name, role);
}