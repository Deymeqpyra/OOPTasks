using System.IO.Compression;
using LectureTask.Services;
using LectureTask.Services.Commands;
using LectureTask.Services.Container;
using LectureTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;



var serviceProvider = IoCContainer.RegisterServices();
var invoker = new Invoker(serviceProvider);

while (true)
{
    invoker.ShowCommands();
    var choice = Console.ReadLine()?.ToUpper();

    if (!invoker.ExecuteCommand(choice))
    {
        break;
    }
}




