using LectureTask.Services;
using LectureTask.Services.Commands;
using LectureTask.Services.Interfaces;

namespace ZipProgramTest;

public class CommandTest
{
    [Fact]
    public void ZipFileCommandShouldCreateZipFile()
    {
        string sourceFilePath = "C:\\Users\\deyme\\Desktop\\newtest.txt";
        string zipFilePath = "C:\\Users\\deyme\\Desktop\\testDestination.zip";

        File.WriteAllText(sourceFilePath, "This is a test file.");

        var strategy = new LowCompressionStrategy();
        var command = new ZipFileCompressionCommand();
        command.SetProperties(sourceFilePath,zipFilePath,strategy);

        // Act
        command.Execute();

        // Assert
        Assert.True(File.Exists(zipFilePath), "The zip file was created successfully.");
        if (File.Exists(sourceFilePath))
            File.Delete(sourceFilePath);
        if (File.Exists(zipFilePath))
            File.Delete(zipFilePath);
    }

    [Fact]
    public void ZipFileNotShouldCreateBecauseFileNotExist()
    {
        //Arrange
        string sourceFilePath = "C:\\Users\\deyme\\Desktop\\thisFileNotExsist.txt";
        string zipFilePath = "C:\\Users\\deyme\\Desktop\\testNotFileDestination.zip";

        var strategy = new LowCompressionStrategy();
        var command = new ZipFileCompressionCommand();
        command.SetProperties(sourceFilePath,zipFilePath,strategy);
        // Act 
        var exception = Assert.Throws<FileNotFoundException>(() => command.Execute());
        
        // Assert
        Assert.Contains("does not exist", exception.Message);
        if (File.Exists(zipFilePath))
            File.Delete(zipFilePath);
    }
}