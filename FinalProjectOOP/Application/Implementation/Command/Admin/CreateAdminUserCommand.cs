using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
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
        const int minRequiredLength = 8;
        if (adminRole.Password.Length < minRequiredLength)
        {
            logger.WarnMessage("Password length is too short.");
            throw new PasswordIsWeakException();
        }
        if (!adminRole.Name.Any())
        {
            logger.WarnMessage("UserName is empty.");
            throw new UserNameIsEmpty();
        }
        try
        {
            var user = await userManager.CreateUser(adminRole.Name, admin, [adminRole.Password], cancellationToken);
            logger.InfoMessage($"Successfully created admin user with name {adminRole.Name}.");
            return user;
        }
        catch (Exception e)
        {
            logger.ErrorMessage($"While created user {e.Message}", nameof(CreateAdminUserCommand));
            throw new UserUnknownException();
        }
    }
}