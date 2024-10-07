using Foodieland.Domain.UserAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    
    Task<User?> GetUserById(UserId userId);
    
    Task AddUser(User user);
    
    void DeleteUser(User user);
}