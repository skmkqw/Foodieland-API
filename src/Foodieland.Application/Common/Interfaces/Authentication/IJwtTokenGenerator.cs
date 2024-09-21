using Foodieland.Domain.UserAggregate;

namespace Foodieland.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}