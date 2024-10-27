namespace SqlBuilderProgramLab10.Entity;

public class Query
{
    private string _commandText;
    private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

    public Query(string commandText)
    {
        this._commandText = commandText;
    }

    public string this[string key]
    {
        get
        {
            return parameters[key];
        }
        set
        {
            parameters[key] = value;
        }
    }

    public void CommandText() => Console.WriteLine(_commandText);

    public void CommandParamets()
    {
        foreach (var param in parameters)
        {
            Console.WriteLine($"{param.Key} {param.Value}");
        }
    }
}