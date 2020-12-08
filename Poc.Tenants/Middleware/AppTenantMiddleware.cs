using Microsoft.AspNetCore.Http;
using Poc.Tenants.Models.Commom;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.Tenants.Middleware
{
    public class AppTenantMiddleware : ITenantResolver<AppTenant>
    {
        public Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
        {
            const string defaultHeader = "register-number";

            if (context.Request.Headers.ContainsKey(defaultHeader))
            {
                var appTenant = new AppTenant(context.Request.Headers[defaultHeader]);
                var tenantContext = new TenantContext<AppTenant>(appTenant);
                return Task.FromResult(tenantContext);
            }

            return Task.FromResult<TenantContext<AppTenant>>(null);
        }
    }
}
