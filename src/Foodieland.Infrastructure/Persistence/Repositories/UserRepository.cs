using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.UserAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodielandDbContext _dbContext;

    public UserRepository(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserById(UserId userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }

    public async Task AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public void DeleteUser(User user)
    {
        _dbContext.Users.Remove(user);
    }
}