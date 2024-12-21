using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
using Domain.Admin;
using Domain.User;

namespace Application.Implementation.Factory;

public class AdminFactory : IUserFactory
{
    public const string adminRole = "Admin";
    public User CreateUser(string name, params object[] additionalParams)
    {
        if (additionalParams[0] is not string password && additionalParams.Length < 1)
        {
            throw new AdminException("The parameters passed are invalid.");
        }
        string passwordFromParameters = additionalParams[0].ToString()!;
        
        return Admin.Create(UserId.New(), passwordFromParameters, name, adminRole);
    }
}