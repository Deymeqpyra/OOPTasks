using System.IO.Compression;
using LectureTask.Services;

namespace ZipProgramTest;

public class StrategyTest
{
    [Fact]
    public void StrategyCompressShouldCreateZipFile()
    {
        // Arrange
        var compressor = new MediumCompressionStrategy();
        var sourceFile = "source.txt";
        var targetFile = "target.zip";
        File.WriteAllText(sourceFile, "Test content");

        // Act
        compressor.Compress(sourceFile, targetFile, false);

        // Assert
        Assert.True(File.Exists(targetFile));

        File.Delete(sourceFile);
        File.Delete(targetFile);
    }

    [Fact]
    public void CompressShouldThrowArgumentNullExceptionBecauseTargetFilePathIsNull()
    {
        // Arrange
        var compressor = new LowCompressionStrategy();

        // Act 
        var exception = Assert.Throws<ArgumentNullException>(() =>
            compressor.Compress("source.txt", null, false));
        
        // Assert
        Assert.Contains("targetFilePath", exception.Message);
    }
}