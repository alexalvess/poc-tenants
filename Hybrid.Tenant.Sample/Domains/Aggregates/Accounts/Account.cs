using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;

namespace Hybrid.Tenant.Sample.Domains.Aggregates.Accounts;

public class Account : AggregateRoot, IAccount
{
    protected override bool Validate()
        => OnValidate<AccountValidator, Account>();
}
