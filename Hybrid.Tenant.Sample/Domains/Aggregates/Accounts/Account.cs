using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;

namespace Hybrid.Tenant.Sample.Domains.Aggregates.Accounts;

public class Account : AggregateRoot, IAccount
{
    public string Name { get; private set; }

    public string Email { get; private set; }

    public byte Password { get; private set; }

    protected override bool Validate()
        => OnValidate<AccountValidator, Account>();
}
