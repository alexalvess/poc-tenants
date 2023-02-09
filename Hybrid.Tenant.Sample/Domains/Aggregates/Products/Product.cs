using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;

namespace Hybrid.Tenant.Sample.Domains.Aggregates.Products;

public class Product : AggregateRoot, IProduct
{
    protected override bool Validate()
        => OnValidate<ProductValidator, Product>();
}
