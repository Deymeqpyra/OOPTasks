using Application.Abstraction.Interfaces;
using Domain.User;
using MediatR;

namespace Application.Implementation.Command.Admin;

public class CreateAdminUserCommand : IRequest<User>
{
    public required string Name { get; init; }
    public required string Password { get; init; }
}

public class CreateAdminUserCommandHandler(IUserManager userManager, ILogger logger) : IRequestHandler<CreateAdminUserCommand, User>
{
    public async Task<User> Handle(CreateAdminUserCommand adminRole, CancellationToken cancellationToken)
    {
        const string admin = "Admin";
        try
        {
            var user = await userManager.CreateUser(adminRole.Name, admin, [adminRole.Password], cancellationToken);
            logger.InfoMessage($"Successfully created admin user with name {adminRole.Name}.");
            return user;
        }
        catch (Exception e)
        {
            logger.ErrorMessage($"While created user {e.Message}");
            throw;
        }
    }
}