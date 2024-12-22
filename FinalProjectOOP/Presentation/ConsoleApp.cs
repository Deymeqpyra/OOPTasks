using Application.Abstraction.Interfaces;
using Application.Implementation.Command.Admin;
using Application.Implementation.Command.Guest;
using MediatR;
using Presentation.Enum;

namespace Presentation;

public class ConsoleApp(ISender sender, IUserManager userManager)
{
    private CancellationToken cancellationToken = new();
    private const string createAdminUser = "Create Admin User";
    private const string deleteAdminUser = "Delete Admin User";
    private const string createGuestUser = "Create Guest User";
    private const string deleteGuestUser = "Delete Guest User";
    private const string getUsers = "Get Users";
    private const string exit = "Exit";
    
    private const string codeSuccess = "[CODE] 200 SUCCESS";
    private const string codeUnknown = "[CODE] 500 INTERNAL SERVER ERROR";
    private const string codeNotFound = "[CODE] 404 NOT FOUND";


    public async Task RunAsync()
    {
        Console.WriteLine("Console Application with EF Core using Clean Architecture");

        var menu = new Dictionary<int, string>
        {
            { (int)ConsoleMenuChoice.CreateAdmin, createAdminUser },
            { (int)ConsoleMenuChoice.DeleteAdmin, deleteAdminUser },
            { (int)ConsoleMenuChoice.CreateGuest, createGuestUser },
            { (int)ConsoleMenuChoice.DeleteGuest, deleteGuestUser },
            { (int)ConsoleMenuChoice.GetUsers, getUsers },
            { (int)ConsoleMenuChoice.Exit, exit }
        };

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            foreach (var option in menu)
            {
                Console.WriteLine($"{option.Key}. {option.Value}");
            }

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch ((ConsoleMenuChoice)choice)
            {
                case ConsoleMenuChoice.CreateAdmin:
                    await CreateAdminUserAsync();
                    break;
                case ConsoleMenuChoice.DeleteAdmin:
                    await DeleteAdminUserAsync();
                    break;
                case ConsoleMenuChoice.CreateGuest:
                    await CreateGuestUserAsync();
                    break;
                case ConsoleMenuChoice.DeleteGuest:
                    await DeleteGuestUserAsync();
                    break;
                case ConsoleMenuChoice.GetUsers:
                    await GetUsersAsync();
                    break;
                case ConsoleMenuChoice.Exit:
                    Console.WriteLine("Exiting application. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private async Task DeleteAdminUserAsync()
    {
        Console.WriteLine("Write the ID of user to delete");
        Guid userToDeleteId = Guid.Parse(Console.ReadLine());
        var input = new DeleteAdminUserCommand
        {
            AdminId = userToDeleteId
        };
        try
        {
            Console.WriteLine(codeSuccess);
            await sender.Send(input, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{codeUnknown} " + e.Message);
            throw;
        }
    }

    private async Task DeleteGuestUserAsync()
    {
        Console.WriteLine("Write the ID of user to delete");
        Guid userToDeleteId = Guid.Parse(Console.ReadLine());
        var input = new DeleteGuestUserCommand()
        {
            UserId = userToDeleteId
        };
        try
        {
            Console.WriteLine(codeSuccess);
            await sender.Send(input, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{codeUnknown} " + e.Message);
            throw;
        }
    }

    private async Task CreateAdminUserAsync()
    {
        Console.WriteLine("Write the Admin name");
        string name = Console.ReadLine();
        Console.WriteLine("Write the Admin password");
        string password = Console.ReadLine();
        var input = new CreateAdminUserCommand
        {
            Name = name,
            Password = password
        };
        try
        {
            Console.WriteLine(codeSuccess);
            await sender.Send(input, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{codeUnknown} " + e.Message);
            throw;
        }
    }

    private async Task CreateGuestUserAsync()
    {
        Console.WriteLine("Write the Guest name");
        string name = Console.ReadLine();
        var input = new CreateGuestUserCommand
        {
            Name = name
        };
        try
        {
            Console.WriteLine(codeSuccess);
            await sender.Send(input, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{codeUnknown} " + e.Message);
            throw;
        }
    }

    private async Task GetUsersAsync()
    {
        Console.WriteLine("List of users:");
        var userList = await userManager.GetUsers(cancellationToken);
        if (userList == null)
        {
            Console.WriteLine(codeNotFound);
        }
        int number = 0;
        const int stepToAdd = 1;
        foreach (var users in userList)
        {
            number += stepToAdd;
            Console.WriteLine(number + $"[{users.Id}] - Name: {users.Name} | Role: {users.Role}");
        }
    }
}