using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;
using Hybrid.Tenant.Sample.Domains.Enumerations;
using Hybrid.Tenant.Sample.Models;

namespace Hybrid.Tenant.Sample.Domains.Aggregates.Products;

public class Product : AggregateRoot, IProduct
{
    public string Name { get; private set; }

    public ProductType Type { get; private set; }

    public decimal Value { get; private set; }

    public DateTimeOffset AcquiredAt { get; }
        = DateTimeOffset.Now;

    public void Handle(ProductModel.AcquireProduct model)
    {
        Name= model.Name;
        Type= model.Type;
        Value= model.Value;
    }

    protected override bool Validate()
        => OnValidate<ProductValidator, Product>();
}