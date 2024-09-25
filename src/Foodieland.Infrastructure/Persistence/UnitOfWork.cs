using Foodieland.Application.Common.Interfaces.Persistence;

namespace Foodieland.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly FoodielandDbContext _dbContext;

    public UnitOfWork(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}