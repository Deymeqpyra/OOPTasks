using Domain.Admin;
using Domain.Guest;
using Domain.User;

namespace ProjectTest.Data;

public static class UserData
{
    const string passwordAdmin = "admin";
    const string adminName = "Admin";
    const string adminRole = "Admin";
    public static Admin AdminUser()
        => Admin.Create(UserId.New(), passwordAdmin, adminName, adminRole);
    public static Guest GuestUser()
        => Guest.Create(UserId.New(), DateTime.UtcNow, adminName, adminRole);
}