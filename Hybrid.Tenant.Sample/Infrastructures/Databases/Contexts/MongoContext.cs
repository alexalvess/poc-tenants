using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;
using Hybrid.Tenant.Sample.Infrastructures.MultiTenancy;
using MongoDB.Driver;

namespace Hybrid.Tenant.Sample.Infrastructures.Databases.Contexts;

public class MongoContext : IMongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(AppTenant appTenant, IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
        _database = mongoClient.GetDatabase(appTenant.User);
    }

    public IMongoCollection<TCollection> Collection<TCollection>()
        where TCollection : class, IAggregateRoot
        => _database.GetCollection<TCollection>(typeof(TCollection).Name);
}
