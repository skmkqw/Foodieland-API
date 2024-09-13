using Foodieland.Application.Common.Interfaces.Services;

namespace Foodieland.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}