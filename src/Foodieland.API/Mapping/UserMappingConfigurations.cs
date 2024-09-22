using Foodieland.Application.Users.Commands;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace Foodieland.API.Mapping;

public class UserMappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid UserId, Guid userIdFromClaim), DeleteUserCommand>()
            .Map(dest => dest.UserIdFromClaim, src => UserId.Create(src.userIdFromClaim))
            .Map(dest => dest.UserId, src => UserId.Create(src.UserId));
    }
}