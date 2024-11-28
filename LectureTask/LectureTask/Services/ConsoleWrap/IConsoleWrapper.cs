namespace LectureTask.Services.ConsoleWrap;

public interface IConsoleWrapper
{
    void DisplayText(string text);
    void ShowCommand(string key, string command);
    (string sourcePath, string targetPath, string strategy) CommandQueue();
    (string sourcePath, string destinationPath) CommandUnzip();
}