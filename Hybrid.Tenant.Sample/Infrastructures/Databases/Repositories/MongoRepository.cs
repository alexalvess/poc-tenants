using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;
using Hybrid.Tenant.Sample.Infrastructures.Databases.Contexts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Hybrid.Tenant.Sample.Infrastructures.Databases.Repositories;

public class MongoRepository : IMongoRepository
{
    private readonly IMongoContext _context;

	public MongoRepository(IMongoContext context)
        => _context = context;

    public async Task<Guid> InsertAsync<TCollection>(TCollection collection, CancellationToken cancellationToken)
        where TCollection : class, IAggregateRoot
    {
        await _context.Collection<TCollection>().InsertOneAsync(collection, default, cancellationToken);
        return collection.Id;
    }

    public Task<TCollection> FindAsync<TCollection>(Expression<Func<TCollection, bool>> predicate, CancellationToken cancellationToken)
        where TCollection : class, IAggregateRoot
        => _context.Collection<TCollection>().AsQueryable().Where(predicate).FirstOrDefaultAsync(cancellationToken);

    public Task<List<TCollection>> ListAsync<TCollection>(CancellationToken cancellationToken)
        where TCollection : class, IAggregateRoot
        => _context.Collection<TCollection>().AsQueryable().ToListAsync(cancellationToken);
}
