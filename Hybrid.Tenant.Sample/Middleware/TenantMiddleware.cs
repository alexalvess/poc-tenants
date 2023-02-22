using Hybrid.Tenant.Sample.Infrastructures.MultiTenancy;
using Microsoft.Extensions.Primitives;
using SaasKit.Multitenancy;

namespace Hybrid.Tenant.Sample.Middleware;

public class TenantMiddleware : ITenantResolver<AppTenant>
{
    public Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
    {
        TenantContext<AppTenant> tenantContext = default;

        if (context.Request.Headers.TryGetValue("x-user", out StringValues user))
            tenantContext = new(new AppTenant(user));

        return Task.FromResult(tenantContext);
    }
}