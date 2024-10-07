namespace Foodieland.Contracts.Common;

public record PaginationResponse(int Page, int PageSize, int TotalCount);