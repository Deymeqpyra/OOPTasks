
namespace Domain.User;

public class User
{
    public UserId Id { get; }
    
    public string Name { get; private set; }
    public string Role { get; private set; } 

    public User(UserId id, string name, string role)    
    {
        Id = id;
        Name = name;
        Role = role;
    }
}