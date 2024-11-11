namespace LectureTask.Services;

public interface ILogger
{
    void AddInfoMessage(string message);
    void AddErrorMessage(string message);
    List<string> GetAllMessages();
}