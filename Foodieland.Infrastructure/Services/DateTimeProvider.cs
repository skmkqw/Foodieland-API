using Foodieland.Application.Common.Services;

namespace Foodieland.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}