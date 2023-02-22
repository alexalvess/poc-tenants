using Hybrid.Tenant.Sample.Domains.Enumerations;

namespace Hybrid.Tenant.Sample.Models;

public static class AccountModel
{
    public record RegisterAccount(string Name, string Email, string Password);

    public record AccessAccount(string Password);
}