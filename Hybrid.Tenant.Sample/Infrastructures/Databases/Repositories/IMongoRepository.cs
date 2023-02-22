using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;
using System.Linq.Expressions;

namespace Hybrid.Tenant.Sample.Infrastructures.Databases.Repositories;

public interface IMongoRepository
{
    Task<Guid> InsertAsync<TCollection>(TCollection collection, CancellationToken cancellationToken)
        where TCollection : class, IAggregateRoot;

    Task<TCollection> FindAsync<TCollection>(Expression<Func<TCollection, bool>> predicate, CancellationToken cancellationToken)
        where TCollection : class, IAggregateRoot;

    Task<List<TCollection>> ListAsync<TCollection>(CancellationToken cancellationToken)
        where TCollection : class, IAggregateRoot;


}
