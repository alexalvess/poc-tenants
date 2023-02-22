namespace Hybrid.Tenant.Sample.Infrastructures.MultiTenancy;

public class AppTenant
{
	public AppTenant(string user)
		=> User = user;

	public string User { get; }
}
