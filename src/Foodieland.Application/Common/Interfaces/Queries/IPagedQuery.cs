namespace Foodieland.Application.Common.Interfaces.Queries;

public interface IPagedQuery
{
    public int Page { get; }

    public int PageSize { get; }
}