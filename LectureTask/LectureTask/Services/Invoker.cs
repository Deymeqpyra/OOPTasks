using System.IO.Compression;
using LectureTask.Services.Commands;
using LectureTask.Services.Container;
using LectureTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LectureTask.Services;

public class Invoker
{
    private readonly Dictionary<string, ICompressionStrategy> _strategy;
    private readonly Dictionary<string, (Func<ICommand> CommandFactory, string Description)> _commands;

    private IServiceProvider _serviceProvider;

    public Invoker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _strategy = new Dictionary<string, ICompressionStrategy>
        {
            {"A", (serviceProvider.GetService<HighCompressionStrategy>()) },
            {"B", (serviceProvider.GetService<MediumCompressionStrategy>()) },
            {"C", (serviceProvider.GetService<LowCompressionStrategy>()) }
        };
        _commands = new Dictionary<string, (Func<ICommand>, string)>
        {
            { "A", (() => ZipFileCommand(), "Zip a file") },
            { "B", (() => ZipFolderCommand(), "Zip a folder") },
            { "U", (() => UnzipArchiveCommand(), "Unzip an archive") },
            { "E", (() => ExitMenuCommand(), "Exit") }
        };
    }
    public void ShowCommands()
    {
        Console.WriteLine("Choose command:");
        foreach (var cmd in _commands)
        {
            Console.WriteLine($"{cmd.Key} - {cmd.Value.Description}");
        }
    }

    private ICommand ExitMenuCommand()
    {
        Console.WriteLine("GoodBye!");
        Thread.Sleep(500);
        var exitCommand = new ExitCommand();
        return exitCommand;
    }

    private ICommand UnzipArchiveCommand()
    {
        Console.WriteLine("Enter zip file path");
        var sourcePath = Console.ReadLine();
        Console.WriteLine("Enter zip file name");
        var targetPath = Console.ReadLine();
        var unZipCommand = new UnZipCommand(sourcePath, targetPath);
        return unZipCommand;
    }

    private ICommand ZipFolderCommand()
    {
        var queue = CommandQueue();

        var zipCommand = new ZipFolderCompressionCommand(queue.sourcePath, queue.targetPath);
        zipCommand.SetStrategy(queue.strategy);
        return zipCommand;
    }

    private ICommand ZipFileCommand()
    {
        var queue = CommandQueue();

        var zipCommand = new ZipFileCompressionCommand(queue.sourcePath, queue.targetPath);
        zipCommand.SetStrategy(queue.strategy);
        return zipCommand;
    }

    public bool ExecuteCommand(string choice)
    {
        if (_commands.TryGetValue(choice, out var commandInfo))
        {
            var command = commandInfo.CommandFactory();
            command.Execute();
            return true;
        }

        Console.WriteLine("Invalid command. Please try again.");
        return true;
    }
   
    private (string sourcePath, string targetPath, ICompressionStrategy strategy) CommandQueue()
    {
        Console.WriteLine("Enter zip file path");
        var sourcePath = Console.ReadLine();
        Console.WriteLine("Enter zip file name");
        var targetPath = Console.ReadLine();
        Console.Write("Choose compression level:\n A - Fastest \n B - Optimal \n C - NoCompression \n ");
        var choice = Console.ReadLine()!.ToUpper();

        if (!_strategy.TryGetValue(choice, out var compressionStrategy))
        {
            throw new ArgumentException("Invalid compression level");
        }
        
        return (sourcePath!, targetPath!, compressionStrategy);
    }
}