using LectureTask.Services.Interfaces;
using System.IO.Compression;

namespace LectureTask.Services.Commands;

public class ZipFileCompressionCommand : ICommand
{
    private string _sourceFilePath;
    private string _zipFilePath;
    private ICompressionStrategy _strategy;

    public void Execute()
    {
        if (_strategy == null)
            throw new InvalidOperationException("Compression strategy not set.");
        if (_sourceFilePath == null)
            throw new InvalidOperationException("Source path not set.");
        if (_zipFilePath == null)
            throw new InvalidOperationException("Destination path not set.");
        _strategy.Compress(_sourceFilePath, _zipFilePath, false);
    }

    public void SetProperties(string sourceFilePath, string zipFilePath, ICompressionStrategy strategy)
    {
        _sourceFilePath = sourceFilePath;
        _zipFilePath = zipFilePath;
        _strategy = strategy;
    }
}