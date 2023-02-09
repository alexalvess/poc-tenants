using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;
using Hybrid.Tenant.Sample.Domains.Enumerations;

namespace Hybrid.Tenant.Sample.Domains.Aggregates.Products;

public class Product : AggregateRoot, IProduct
{
    public string Name { get; private set; }

    public ProductType Type { get; private set; }

    public decimal Value { get; private set; }

    public DateTimeOffset AcquiredAt { get; }
        = DateTimeOffset.Now;

    protected override bool Validate()
        => OnValidate<ProductValidator, Product>();
}