using Hybrid.Tenant.Sample.Domains.Aggregates.Products;
using Hybrid.Tenant.Sample.Infrastructures.Databases.Contexts;
using Hybrid.Tenant.Sample.Infrastructures.Databases.Repositories;
using Hybrid.Tenant.Sample.Models;
using Hybrid.Tenant.Sample.UseCases.Abstractions.UseCases;

namespace Hybrid.Tenant.Sample.UseCases.ProductUseCases;

public class RegisterProductUseCase : IInteractorUseCase<ProductModel.AcquireProduct, Guid>
{
    private readonly IMongoRepository _repository;

    public RegisterProductUseCase(IMongoRepository repository)
        => _repository = repository;

    public async Task<Guid> InteractAsync(string user, ProductModel.AcquireProduct request, CancellationToken cancellationToken)
    {
        Product product = new();
        product.Handle(request);
        await _repository.InsertAsync(product, cancellationToken);
        return product.Id;
    }
}
