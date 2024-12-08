namespace Laboratory11.Services;

public interface IConsoleWrapper
{
    string Read(string prompt);
    void Write(string prompt);
}