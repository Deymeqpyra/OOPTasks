using Domain.User;
using Optional;

namespace Application.Abstraction.Interfaces;

public interface IUserRepository
{
    Task<Option<User>> GetUserByIdAsync(UserId userId, CancellationToken cancellationToken);
    Task<User> Create(User user, CancellationToken cancellationToken);
    Task<User> Update(User user, CancellationToken cancellationToken);
    Task<User> Delete(User user, CancellationToken cancellationToken);
}