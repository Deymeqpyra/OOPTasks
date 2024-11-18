using System.IO.Compression;
using LectureTask.Services;
using LectureTask.Services.Commands;
using LectureTask.Services.Container;
using LectureTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;


var serviceProvider = new ServiceCollection()
    .RegisterServices()
    .BuildServiceProvider();
var invoker = new Invoker(serviceProvider);

invoker.Run();