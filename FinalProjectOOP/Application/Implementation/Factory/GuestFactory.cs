using Application.Abstraction.Interfaces;
using Application.Implementation.Exceptions.User;
using Domain.Admin;
using Domain.Guest;
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
        DateTime dateWasCreated = additionalParams[0] is DateTime ? (DateTime)additionalParams[0] : default;
        
        return Guest.Create(UserId.New(), dateWasCreated , name, guestRole);
    }
}