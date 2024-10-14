namespace Lab10OOP.Entity;

public class User()
{
    private string _name { get; set; }
    private int _age { get; set; }
    private  string _email { get; set; }
    public List<Category> SubscribedCategories { get; set; }
 

    public string Name
    {
        get { return _name; }
        set { if(value != "") _name = value; }
    }
    public string Email
    {
        get { return _email; }
        set { if(value.Contains('@') || value.Contains('.')) _email = value; }
    }
    public int Age
    {
        get { return _age; }
        set { if(value > 0) _age = value; }
    }
}