using System.Collections;
using Application.Abstraction.Interfaces;
using Application.Abstraction.Queries;
using Application.Implementation.Exceptions.User;
using Application.Implementation.Factory;
using Domain.User;
using Optional;

namespace Application.Implementation.Manager;

public class UserManager : IUserManager, IEnumerable<User>
{
    private readonly IUserRepository userRepository;
    private readonly IUserQueries userQueries;
    private readonly ILogger logger;
    private readonly Dictionary<string, IUserFactory> _factories;
    private readonly List<User> _usersList;


    public UserManager(IUserRepository userRepository, IUserQueries userQueries, ILogger logger)
    {
        this.userRepository = userRepository;
        this.userQueries = userQueries;
        this.logger = logger;
        _usersList = new List<User>();
        _factories = new Dictionary<string, IUserFactory>
        {
            { "Admin", new AdminFactory() },
            { "Guest", new GuestFactory() }
        };
    }

    public async Task<IReadOnlyList<User>> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            var users = await userQueries.GetAllUsersAsync(cancellationToken);
            _usersList.AddRange(users);
            logger.InfoMessage($"Found {users.Count} users, while fetching all users.");
            return users;
        }
        catch (Exception e)
        {
            _usersList.Clear();
            logger.ErrorMessage($"While fetching all users error message: {e.Message}", nameof(UserManager));
            throw new NoUsersFoundException();
        }
    }

    public async Task<User> CreateUser(string name, string role, object[] additionalParams,
        CancellationToken cancellationToken)
    {
        var userFactory = GetUserFactory(role);
        if (userFactory == null)
        {
            logger.ErrorMessage($"User type was not found, while creating a new user factory.", nameof(UserManager));
            throw new UserFactoryNotFoundException();
        }

        if (name == null || additionalParams == null)
        {
            logger.ErrorMessage($"Name and role and additional parameters are required.", nameof(name));
            throw new EmptyCrenditalsException();
        }
        try
        {
            var user = userFactory.CreateUser(name, additionalParams);
            logger.InfoMessage($"Created user with id: {user.Id}");
            return await userRepository.Create(user, cancellationToken);
        }
        catch (Exception e)
        {
            logger.ErrorMessage($"While creating user in manager occured error message: {e.Message}",
                nameof(UserManager));
            throw new UserUnknownException();
        }
    }

    public async Task<User> DeleteUser(User user, CancellationToken cancellationToken)
    {
        try
        {
            var userFromResponse =  await userRepository.Delete(user, cancellationToken); 
            logger.InfoMessage($"Deleted user with id: {user.Id}");
            return userFromResponse;
        }
        catch (Exception e)
        {
            logger.ErrorMessage($"While deleting user error message: {e.Message}", nameof(UserManager));
            throw new UserUnknownException();
        }
    }

    private IUserFactory GetUserFactory(string userType)
    {
        if (_factories.ContainsKey(userType))
        {
            logger.InfoMessage($"Found user type: {userType}");
            return _factories[userType];
        }
        logger.ErrorMessage($"User type {userType} was not found.", nameof(UserManager));
        return null;
    }
    
    public IEnumerator<User> GetEnumerator()
    {
        foreach (var user in _usersList)
        {
            yield return user;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}