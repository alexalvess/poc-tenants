using Hybrid.Tenant.Sample.Domains.Enumerations;

namespace Hybrid.Tenant.Sample.Models;

public static class ProductModel
{
    public record AcquireProduct(string Name, ProductType Type, decimal Value);

    public record RecoverProduct(string Name, ProductType Type, decimal Value, DateTimeOffset AcquiredAt);
}
