using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
using Domain.User;
using MediatR;

namespace Application.Implementation.Command.Guest;

public class CreateGuestUserCommand : IRequest<User>
{
    public required string Name { get; init; }
}

public class CreateGuestUserCommandHandler(IUserManager userManager, ILogger logger) : IRequestHandler<CreateGuestUserCommand, User>
{
    public async Task<User> Handle(CreateGuestUserCommand request, CancellationToken cancellationToken)
    {
        const string guestRole = "Guest";
        try
        {
            var user = await userManager.CreateUser(request.Name, guestRole, [DateTime.UtcNow], cancellationToken);
            logger.InfoMessage($"Guest successfully logged in. Id: {user.Id}");
            return user;
        }
        catch (Exception e)
        {
            logger.ErrorMessage($"Error creating guest user. Exception Message: {e.Message}", nameof(CreateGuestUserCommandHandler));
            throw new UserUnknownException();
        }
    }
}