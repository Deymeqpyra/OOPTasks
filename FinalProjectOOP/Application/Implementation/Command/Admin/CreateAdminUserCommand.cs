using Application.Abstraction.Interfaces;
using Domain.User;
using MediatR;

namespace Application.Implementation.Command.Admin;

public class CreateAdminUserCommand : IRequest<User>
{
    public required string Name { get; init; }
    public required string Password { get; init; }
}

public class CreateAdminUserCommandHandler(IUserManager userManager) : IRequestHandler<CreateAdminUserCommand, User>
{
    public async Task<User> Handle(CreateAdminUserCommand adminRole, CancellationToken cancellationToken)
    {
        const string admin = "Admin";
        return await userManager.CreateUser(adminRole.Name, admin, [adminRole.Password], cancellationToken);
    }
}