using LectureTask.Services.Interfaces;

namespace LectureTask.Services.Commands;

public class ExitCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Exit");
        Environment.Exit(0);
    }
}