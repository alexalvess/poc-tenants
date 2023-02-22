using Hybrid.Tenant.Sample.Domains.Aggregates.Accounts;
using Hybrid.Tenant.Sample.Infrastructures.Databases.Repositories;
using Hybrid.Tenant.Sample.Models;
using Hybrid.Tenant.Sample.UseCases.Abstractions.UseCases;

namespace Hybrid.Tenant.Sample.UseCases.AccountUseCases;

public class RegisterAccountUseCase : IInteractorUseCase<AccountModel.RegisterAccount, Guid>
{
    private readonly IMongoRepository _repository;

    public RegisterAccountUseCase(IMongoRepository repository)
        => _repository = repository;

    public async Task<Guid> InteractAsync(string user, AccountModel.RegisterAccount request, CancellationToken cancellationToken)
    {
        Account account = new();
        account.Handle(user, request);
        await _repository.InsertAsync(account, cancellationToken);
        return account.Id;
    }
}
