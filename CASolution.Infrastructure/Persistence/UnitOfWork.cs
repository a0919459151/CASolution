using CASolution.Application.Interfaces.Persistence;

namespace CASolution.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{

    private readonly CASolutionDbContext _dbContext;

    public UnitOfWork(CASolutionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}