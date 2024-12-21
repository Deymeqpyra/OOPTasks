using Domain.Admin;
using Domain.User;

namespace Application.Abstraction.Interfaces;

public interface IUserFactory
{
    User CreateUser(string name, params object[] additionalParams);
}