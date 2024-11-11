namespace LectureTask.Services;

public class Logger : ILogger
{
    private List<string> _messages { get; set; } = new List<string>();

    public void AddInfoMessage(string message)
    {
        _messages.Add($"{DateTime.Now} INFO: {message}");
    }
    public void AddErrorMessage(string message)
    {
        _messages.Add($"{DateTime.Now} ERROR: {message}");
    }
    public List<string> GetAllMessages()
    {
        return _messages.ToList();
    }
}