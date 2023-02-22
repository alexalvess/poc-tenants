
using Hybrid.Tenant.Sample.Domains.Aggregates.Accounts;
using Hybrid.Tenant.Sample.Infrastructures.Databases.Repositories;
using Hybrid.Tenant.Sample.Models;
using Hybrid.Tenant.Sample.UseCases.Abstractions.UseCases;

namespace Hybrid.Tenant.Sample.UseCases.AccountUseCases;

public class AccessAccountUseCase : IInteractorUseCase<AccountModel.AccessAccount, bool>
{
    private readonly IMongoRepository _repository;

    public AccessAccountUseCase(IMongoRepository repository)
        => _repository = repository;

    public async Task<bool> InteractAsync(string user, AccountModel.AccessAccount request, CancellationToken cancellationToken)
    {
        var account = await _repository.FindAsync<Account>(prop => prop.Nin.Equals(user), cancellationToken);
        return account.Handle(user, request);
    }
}