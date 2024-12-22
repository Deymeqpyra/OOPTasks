using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
using Domain.User;
using MediatR;

namespace Application.Implementation.Command.Guest;

public class DeleteGuestUserCommand : IRequest<User>
{
    public required Guid UserId { get; init; }
}
public class DeleteGuestUserCommandHandler(IUserManager userManager, IUserRepository repository, ILogger logger) : IRequestHandler<DeleteGuestUserCommand, User>
{
    public  async Task<User> Handle(DeleteGuestUserCommand request, CancellationToken cancellationToken)
    {
            var guestId = new UserId(request.UserId);
            var guestUser = await repository.GetUserByIdAsync(guestId, cancellationToken);
            return await guestUser.Match(
                async x => await HandleDelete(x, cancellationToken),
                () =>
                {
                    logger.ErrorMessage("User does not exist", nameof(DeleteGuestUserCommand));
                    throw new UserNotFoundException(guestId);
                });
    }

    public async Task<User> HandleDelete(User user, CancellationToken cancellationToken)
    {
        try
        {
            var userFromResponse = await userManager.DeleteUser(user, cancellationToken);
            logger.InfoMessage($"User was deleted successfully with id: {user.Id}");
            return userFromResponse;
        }
        catch (Exception e)
        {
            logger.ErrorMessage($"User could not be deleted. Exception: {e.Message}", nameof(HandleDelete));
            throw new UserUnknownException();
        }
    }
}