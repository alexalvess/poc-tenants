using Hybrid.Tenant.Sample.Domains.Abstractions.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;

namespace Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    [BsonId]
    public Guid Id { get; protected set; }
}
