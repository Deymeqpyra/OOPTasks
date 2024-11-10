using System.IO.Compression;
using LectureTask.Services.Interfaces;

namespace LectureTask.Services.Commands;

public class UnZipCommand : ICommand
{
    private readonly string _zipFilePath;
    private readonly string _destinationPath;

    public UnZipCommand(string zipFilePath, string destinationPath)
    {
        _zipFilePath = zipFilePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        try
        {
            if (!File.Exists(_zipFilePath))
            {
                throw new FileNotFoundException($"The zip file '{_zipFilePath}' does not exist.");
            }

            if (!Directory.Exists(_destinationPath))
            {
                Directory.CreateDirectory(_destinationPath);
            }

            ZipFile.ExtractToDirectory(_zipFilePath, _destinationPath);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}