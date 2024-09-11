using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class User
    {
        public static readonly UserId UserId = UserId.CreateUnique();
    }
}