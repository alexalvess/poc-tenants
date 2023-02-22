using Hybrid.Tenant.Sample.Domains.Aggregates.Products;
using Hybrid.Tenant.Sample.Infrastructures.Databases.Repositories;
using Hybrid.Tenant.Sample.Models;
using Hybrid.Tenant.Sample.UseCases.Abstractions.UseCases;

namespace Hybrid.Tenant.Sample.UseCases.ProductUseCases;

public class RecoverProductsUseCase : IInteractorUseCase<ValueTask, IEnumerable<ProductModel.RecoverProduct>>
{
    private readonly IMongoRepository _repository;

    public RecoverProductsUseCase(IMongoRepository repository)
        => _repository = repository;

    public async Task<IEnumerable<ProductModel.RecoverProduct>> InteractAsync(string user, ValueTask request, CancellationToken cancellationToken)
    {
        var products = await _repository.ListAsync<Product>(cancellationToken);
        return products.Select(product 
            => new ProductModel.RecoverProduct(product.Name, product.Type, product.Value, product.AcquiredAt));
    }
}
