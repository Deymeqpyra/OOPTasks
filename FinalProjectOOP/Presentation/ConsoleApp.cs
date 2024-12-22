using Application.Implementation.Command.Admin;
using Domain.User;
using Infrastructure.Persistence;
using MediatR;

namespace Presentation;

public class ConsoleApp(ISender sender)
{
    public async Task RunAsync()
    {
        Console.WriteLine("Console Application with EF Core using Clean Architecture");

        Console.WriteLine("Execute Command");
        var choice = Console.ReadLine();
        if (choice!.ToLower() == "yes")
        {
            var input = new CreateAdminUserCommand
            {
                Name = "TestAnton12",
                Password = "password1"
            };
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                await sender.Send(input, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}