using Ardalis.SmartEnum;

namespace Hybrid.Tenant.Sample.Domains.Enumerations;

public sealed class ProductType : SmartEnum<ProductType>
{
    public static readonly ProductType Book = new(nameof(Book), 1);
    public static readonly ProductType Banner = new(nameof(Banner), 2);

    public ProductType(string name, int value)
        : base(name, value) { }
}
