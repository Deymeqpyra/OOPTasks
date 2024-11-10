using LectureTask.Services.Interfaces;
using System.IO.Compression;

namespace LectureTask.Services.Commands;

public class ZipFileCompressionCommand : ICommand
{
    private string sourceFilePath;
    private string zipFilePath;
    private ICompressionStrategy _strategy;

    public ZipFileCompressionCommand(string sourceFilePath, string zipFilePath)
    {
        this.sourceFilePath = sourceFilePath;
        this.zipFilePath = zipFilePath;
    }

    public void Execute()
    {
        _strategy.Compress(sourceFilePath, zipFilePath, false);
    }

    public void SetStrategy(ICompressionStrategy strategy)
    {
        if (strategy == null)
        {
            throw new InvalidOperationException("Compression strategy is not set.");
        }
        _strategy = strategy;
    }
}