using System.IO.Compression;
using LectureTask.Services;
using LectureTask.Services.Commands;
using LectureTask.Services.Container;
using LectureTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;



var serviceProvider = IoCContainer.RegisterServices();
var log = serviceProvider.GetService<Logger>();
var invoker = new Invoker(serviceProvider, log);

while (true)
{
    invoker.ShowCommands();
    var choice = Console.ReadLine()?.ToUpper();
    if (choice == "LOGGER")
    {
        foreach (var message in log.GetAllMessages())
        {
            Console.WriteLine(message);
        }
    }
    if (!invoker.ExecuteCommand(choice))
    {
        break;
    }
}




