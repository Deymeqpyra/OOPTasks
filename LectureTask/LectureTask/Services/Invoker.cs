using System.IO.Compression;
using LectureTask.Services.Commands;
using LectureTask.Services.ConsoleWrap;
using LectureTask.Services.Container;
using LectureTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LectureTask.Services;

public class Invoker
{
    private const string ZipFileCommandChar = "A";
    private const string ZipFolderCommandChar = "B";
    private const string ExitCommandChar = "E";
    private const string UnzipCommandChar = "U";

    private const string HighCompressionCommandChar = "A";
    private const string MediumCompressionCommandChar = "B";
    private const string LowCompressionCommandChar = "C";


    private readonly Dictionary<string, ICompressionStrategy> _strategy;
    private readonly Dictionary<string, (Func<ICommand> CommandFactory, string Name)> _commands;
    private IServiceProvider _serviceProvider;
    private IConsoleWrapper _consoleWrapper;

    public Invoker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _consoleWrapper = _serviceProvider.GetService<IConsoleWrapper>();
        _strategy = new Dictionary<string, ICompressionStrategy>
        {
            { HighCompressionCommandChar, _serviceProvider.GetService<HighCompressionStrategy>() },
            { MediumCompressionCommandChar, _serviceProvider.GetService<MediumCompressionStrategy>() },
            { LowCompressionCommandChar, _serviceProvider.GetService<LowCompressionStrategy>()}
        };
        _commands = new Dictionary<string, (Func<ICommand>, string)>
        {
            { ZipFileCommandChar, (() => ZipFileCommand(), "Zip a file") },
            { ZipFolderCommandChar, (() => ZipFolderCommand(), "Zip a folder") },
            { UnzipCommandChar, (() => UnzipArchiveCommand(), "Unzip an archive") },
            { ExitCommandChar, (() => ExitMenuCommand(), "Exit") }
        };
    }

    public void Run()
    {
        while (true)
        {
            ShowCommands();
            string choice = Console.ReadLine().ToUpper();

            try
            {
                ExecuteCommand(choice);
            }
            catch (Exception ex)
            {
                _consoleWrapper.DisplayText($"Error occurred: {ex.Message}");
            }
        }
    }

    public void ShowCommands()
    {
        _consoleWrapper.DisplayText("Commands: ");
        foreach (var cmd in _commands)
        {
            _consoleWrapper.ShowCommand(cmd.Key, cmd.Value.Name);
        }
    }

    private ICommand ExitMenuCommand()
    {
        Thread.Sleep(500);
        var exitCommand = new ExitCommand();
        return exitCommand;
    }

    private ICommand UnzipArchiveCommand()
    {
        var commandProperties = _consoleWrapper.CommandUnzip();
        var unZipCommand = _serviceProvider.GetRequiredService<UnZipCommand>();
        unZipCommand.SetProperties(commandProperties.sourcePath, commandProperties.destinationPath);

        return unZipCommand;
    }

    private ICommand ZipFolderCommand()
    {
        var queue = _consoleWrapper.CommandQueue();

        var zipCommand = _serviceProvider.GetRequiredService<ZipFolderCompressionCommand>();
        if (!_strategy.TryGetValue(queue.strategy, out var compressionStrategy))
        {
            throw new ArgumentException("Invalid compression level");
        }

        zipCommand.SetProperties(queue.sourcePath, queue.targetPath, compressionStrategy);
        return zipCommand;
    }

    private ICommand ZipFileCommand()
    {
        var queue = _consoleWrapper.CommandQueue();
        if (!_strategy.TryGetValue(queue.strategy, out var compressionStrategy))
        {
            throw new ArgumentException("Invalid compression level");
        }

        var zipCommand = _serviceProvider.GetRequiredService<ZipFileCompressionCommand>();
        zipCommand.SetProperties(queue.sourcePath, queue.targetPath, compressionStrategy);
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

        _consoleWrapper.DisplayText("Invalid Input");
        return true;
    }
}