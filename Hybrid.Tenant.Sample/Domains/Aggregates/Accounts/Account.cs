using Hybrid.Tenant.Sample.Domains.Abstractions.Aggregates;
using Hybrid.Tenant.Sample.Domains.Aggregates.Products;
using Hybrid.Tenant.Sample.Models;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

namespace Hybrid.Tenant.Sample.Domains.Aggregates.Accounts;

public class Account : AggregateRoot, IAccount
{
    public string Name { get; private set; }

    public string Nin { get; private set; }

    public string Email { get; private set; }

    public byte[] Password { get; private set; }

    public void Handle(string user, AccountModel.RegisterAccount model)
    {
        Name= model.Name;
        Nin= user;
        Email= model.Email;

        using var hasher = SHA256.Create();
        Password = hasher.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
    }

    public bool Handle(string user, AccountModel.AccessAccount model)
    {
        if (Nin != user)
            return false;

        using var hasher = SHA256.Create();
        var password = hasher.ComputeHash(Encoding.UTF8.GetBytes(model.Password));

        if (Password != password)
            return false;

        return true;
    }

    protected override bool Validate()
        => OnValidate<AccountValidator, Account>();
}