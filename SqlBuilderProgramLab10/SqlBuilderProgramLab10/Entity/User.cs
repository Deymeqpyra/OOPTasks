namespace SqlBuilderProgramLab10.Entity;

public class User
{
    public int UserId { get; set; }
    public DateTime RegestrationDate { get; private init; } = DateTime.UtcNow;
    public string Email { get; set; }
}