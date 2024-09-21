using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.UserAggregate;

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

    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}