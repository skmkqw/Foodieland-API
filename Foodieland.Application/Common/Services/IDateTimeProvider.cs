namespace Foodieland.Application.Common.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}