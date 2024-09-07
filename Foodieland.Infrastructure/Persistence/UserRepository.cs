using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Entities;

namespace Foodieland.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}