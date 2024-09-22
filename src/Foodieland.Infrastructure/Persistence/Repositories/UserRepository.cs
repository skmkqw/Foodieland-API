using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.UserAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodielandDbContext _dbContext;

    public UserRepository(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetUserById(UserId userId)
    {
        return _dbContext.Users.Find(userId);
    }

    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void DeleteUser(User user)
    {
        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
    }
}