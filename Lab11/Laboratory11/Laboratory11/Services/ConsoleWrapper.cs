namespace Laboratory11.Services;

public class ConsoleWrapper : IConsoleWrapper
{
    public string Read(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }

    public void Write(string prompt)
    {
        Console.WriteLine(prompt);
    }
}