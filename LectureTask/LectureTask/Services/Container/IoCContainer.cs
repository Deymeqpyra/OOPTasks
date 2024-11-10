using LectureTask.Services.Commands;
using LectureTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LectureTask.Services.Container;

public static class IoCContainer
{
    public static IServiceProvider RegisterServices()
    {
        return new ServiceCollection()
            .AddSingleton<LowCompressionStrategy>()
            .AddSingleton<MediumCompressionStrategy>()
            .AddSingleton<HighCompressionStrategy>()
            .BuildServiceProvider();
    }
}