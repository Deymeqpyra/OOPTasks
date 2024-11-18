using LectureTask.Services.Interfaces;

namespace LectureTask.Services.ConsoleWrap;

public class ConsoleWrapper : IConsoleWrapper
{
    public void DisplayText(string text)
    {
        Console.WriteLine(text);
    }

    public void ShowCommand(string key, string command)
    {
        Console.WriteLine($"{key}: {command}");
    }

    public (string sourcePath, string targetPath, string strategy) CommandQueue()
    {
        Console.WriteLine($"Enter the full path to the source");
        var sourcePath = Console.ReadLine();
        Console.Write("Enter the full path to the destination zip file ");
        var targetPath = Console.ReadLine();
        Console.WriteLine("Choose compression level:\n A - Fastest \n B - Optimal \n C - NoCompression \n ");
        var choiceStrategy = Console.ReadLine()!.ToUpper();

        return (sourcePath!, targetPath!, choiceStrategy);
    }
}