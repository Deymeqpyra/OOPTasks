using Domain.User;
using Optional;

namespace Application.Abstraction.Queries;

public interface IUserQueries
{
    Task<IReadOnlyList<User>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<Option<User>> GetUserByIdAsync(UserId userId, CancellationToken cancellationToken);
}