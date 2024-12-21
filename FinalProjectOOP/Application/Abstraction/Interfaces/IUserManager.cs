using Domain.User;

namespace Application.Abstraction.Interfaces;

public interface IUserManager
{
    Task<IReadOnlyList<User>> GetUsers(CancellationToken cancellationToken);
    Task<User> CreateUser(string name, string role, object[] additionalParams, CancellationToken cancellationToken);
    Task<User> DeleteUser(User user, CancellationToken cancellationToken);
}