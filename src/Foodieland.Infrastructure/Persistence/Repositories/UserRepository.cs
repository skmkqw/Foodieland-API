using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.UserAggregate;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodielandDbContext _context;
    public User? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}