using Foodieland.Domain.UserAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    
    User? GetUserById(UserId userId);
    
    void AddUser(User user);
    
    void DeleteUser(User user);
}