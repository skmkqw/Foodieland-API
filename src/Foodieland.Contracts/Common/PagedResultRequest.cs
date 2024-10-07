namespace Foodieland.Contracts.Common;

public record PagedResultRequest(int Page = 1, int PageSize = 10);