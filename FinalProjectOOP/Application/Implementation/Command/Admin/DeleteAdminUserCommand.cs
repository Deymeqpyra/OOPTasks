using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
using Domain.User;
using MediatR;

namespace Application.Implementation.Command.Admin;

public class DeleteAdminUserCommand : IRequest<User>
{
    public required Guid AdminId { get; init; }
}

public class DeleteAdminUserCommandHandler(IUserManager userManager, IUserRepository repository, ILogger logger) : IRequestHandler<DeleteAdminUserCommand, User>
{
    public async Task<User> Handle(DeleteAdminUserCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.AdminId);
        var user = await repository.GetUserByIdAsync(userId, cancellationToken);
        return await user.Match(
            async x => await HandleDelete(x, cancellationToken),
            () =>
            {
                logger.ErrorMessage($"User does not exist, with user id: {userId}", nameof(DeleteAdminUserCommandHandler));
                throw new UserNotFoundException(userId);
            });
    }

    private async Task<User> HandleDelete(User user, CancellationToken cancellationToken)
    {
        try
        {
            var userFromResponse = await userManager.DeleteUser(user, cancellationToken);
            logger.InfoMessage($"Successfully deleted user with Id: {user.Id}");
            return userFromResponse;
        }
        catch (Exception e)
        {
            logger.ErrorMessage($"Unknown error while deleting user. Message: {e.Message}", nameof(DeleteAdminUserCommand));
            throw new UserUnknownException();
        }
    }
}