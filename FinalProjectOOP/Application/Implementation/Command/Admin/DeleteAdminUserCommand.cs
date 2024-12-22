using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
using Domain.User;
using MediatR;

namespace Application.Implementation.Command.Admin;

public class DeleteAdminUserCommand : IRequest<User>
{
    public required Guid AdminId { get; init; }
}

public class DeleteAdminUserCommandHandler(IUserManager userManager, IUserRepository repository) : IRequestHandler<DeleteAdminUserCommand, User>
{
    public async Task<User> Handle(DeleteAdminUserCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.AdminId);
        var user = await repository.GetUserByIdAsync(userId, cancellationToken);
        return await user.Match(
            async x => await HandleDelete(x, cancellationToken),
            () => throw new UserNotFoundException(userId));
    }

    private async Task<User> HandleDelete(User user, CancellationToken cancellationToken)
    {
        try
        {
            return await userManager.DeleteUser(user, cancellationToken);
        }
        catch (Exception e)
        {
            // TODO: Logger
            Console.WriteLine(e);
            throw;
        }
    }
}