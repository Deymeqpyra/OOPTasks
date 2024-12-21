using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
using Domain.Admin;
using Domain.User;

namespace Application.Implementation.Factory;

public class GuestFactory : IUserFactory
{
    public const string guestRole = "Guest";
    public User CreateUser(string name, params object[] additionalParams)
    {
        if (additionalParams[0] is not DateTime wasCreated && additionalParams.Length < 1)
        {
            throw new GuestException("The parameters passed are invalid.");
        }
        string passwordFromParameters = additionalParams[0].ToString()!;
        
        return Admin.Create(UserId.New(), passwordFromParameters, name, guestRole);
    }
}