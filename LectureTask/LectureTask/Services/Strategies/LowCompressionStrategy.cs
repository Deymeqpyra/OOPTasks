using System.IO.Compression;
using LectureTask.Services.Commands;
using LectureTask.Services.Interfaces;

namespace LectureTask.Services;

public class LowCompressionStrategy : ICompressionStrategy
{
    public void Compress(string sourceFilePath, string targetFilePath, bool isFolder)
    {
        if (sourceFilePath == null || targetFilePath == null)
        {
            throw new ArgumentNullException(nameof(sourceFilePath),
                nameof(sourceFilePath) + " || " + nameof(targetFilePath));
        }

        if (!File.Exists(sourceFilePath))
        {
            throw new FileNotFoundException($"The file '{sourceFilePath}' does not exist.");
        }

        if (isFolder)
        {
            ZipFile.CreateFromDirectory(sourceFilePath, targetFilePath, CompressionLevel.Fastest, true);
        }

        using (var archive = ZipFile.Open(targetFilePath, ZipArchiveMode.Create))
        {
            archive.CreateEntryFromFile(sourceFilePath, Path.GetFileName(sourceFilePath),
                CompressionLevel.NoCompression);
        }
    }
}