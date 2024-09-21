using Foodieland.Domain.UserAggregate;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    
    void AddUser(User user);
}