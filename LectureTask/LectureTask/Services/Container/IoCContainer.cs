using LectureTask.Services.Commands;
using LectureTask.Services.ConsoleWrap;
using LectureTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LectureTask.Services.Container;

public static class IoCContainer
{
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<LowCompressionStrategy>()
            .AddSingleton<MediumCompressionStrategy>()
            .AddSingleton<HighCompressionStrategy>()
            .AddSingleton<ZipFileCompressionCommand>()
            .AddSingleton<ZipFolderCompressionCommand>()
            .AddSingleton<ExitCommand>()
            .AddSingleton<UnZipCommand>()
            .AddSingleton<IConsoleWrapper, ConsoleWrapper>();
    }
}