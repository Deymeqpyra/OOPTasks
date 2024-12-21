using Application.Abstraction.Interfaces;
using Application.Abstraction.Queries;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Optional;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository, IUserQueries
{
    public async Task<User> Create(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return user;
    }

    public async Task<User> Update(User user, CancellationToken cancellationToken)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return user;
    }

    public async Task<User> Delete(User user, CancellationToken cancellationToken)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return user;
    }

    public async Task<IReadOnlyList<User>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return await context.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Option<User>> GetUserByIdAsync(UserId userId, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id == userId, cancellationToken);
        
        return user == null ? Option.None<User>() : Option.Some(user);
    }
}