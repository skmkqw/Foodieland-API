using Foodieland.Domain.Entities;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    
    void AddUser(User user);
}