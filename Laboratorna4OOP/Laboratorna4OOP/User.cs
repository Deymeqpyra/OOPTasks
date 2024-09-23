namespace Laboratorna4OOP;

public class User(string name, bool isAdmin)
{
    public string Name { get; private set; } = name;
    public bool IsAdmin { get; private set; } = isAdmin;
    public Inventory Inventory { get; private set; } = new Inventory();
}