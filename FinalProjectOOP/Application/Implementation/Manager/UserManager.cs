using Application.Abstraction.Interfaces;
using Application.Abstraction.Queries;
using Application.Implementation.Exceptions.User;
using Application.Implementation.Factory;
using Domain.User;

namespace Application.Implementation.Manager;

public class UserManager : IUserManager
{
    public readonly IUserRepository userRepository;
    public readonly IUserQueries userQueries;
    private readonly Dictionary<string, IUserFactory> _factories;


    public UserManager(IUserRepository userRepository, IUserQueries userQueries)
    {
        this.userRepository = userRepository;
        this.userQueries = userQueries;
        _factories = new Dictionary<string, IUserFactory>
        {
            { "Admin", new AdminFactory() },
            { "Guest", new GuestFactory() }
        };
    }
    
    public async Task<IReadOnlyList<User>> GetUsers(CancellationToken cancellationToken)
    {
        return await userQueries.GetAllUsersAsync(cancellationToken);
    }

    public async Task<User> CreateUser(string name, string role, object[] additionalParams, CancellationToken cancellationToken)
    {
        var userFactory = GetUserFactory(role);
        if (userFactory == null)
        {
            throw new UserFactoryNotFoundException();
        }
        
        var user = userFactory.CreateUser(name, additionalParams);
        return await userRepository.Create(user, cancellationToken);
    }

    public async Task<User> DeleteUser(User user, CancellationToken cancellationToken)
    {
        return await userRepository.Delete(user, cancellationToken);
    }
    
    private IUserFactory GetUserFactory(string userType)
    {
        if (_factories.ContainsKey(userType))
        {
            return _factories[userType];
        }

        return null;
    }
}