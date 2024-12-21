
namespace Domain.User;

public class User
{
    public UserId Id { get; }
    
    private string Name { get; set; }
    private string Role { get; set; } 

    public User(UserId id, string name, string role)    
    {
        Id = id;
        Name = name;
        Role = role;
    }
}