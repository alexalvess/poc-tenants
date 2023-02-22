using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;
using MongoDB.Driver;

namespace Hybrid.Tenant.Sample.Infrastructures.Databases.Contexts;

public interface IMongoContext
{
    IMongoCollection<TCollection> Collection<TCollection>()
        where TCollection : class, IAggregateRoot;
}
