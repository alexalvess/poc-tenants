using Hybrid.Tenant.Sample.Infrastructures.Databases.Contexts;
using Hybrid.Tenant.Sample.Infrastructures.Databases.Repositories;
using Hybrid.Tenant.Sample.Infrastructures.MultiTenancy;
using Hybrid.Tenant.Sample.Middleware;
using Hybrid.Tenant.Sample.Models;
using Hybrid.Tenant.Sample.UseCases.Abstractions.UseCases;
using Hybrid.Tenant.Sample.UseCases.AccountUseCases;
using Hybrid.Tenant.Sample.UseCases.ProductUseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices((context, services) =>
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddMultitenancy<AppTenant, TenantMiddleware>();

    services.AddScoped<IMongoContext, MongoContext>();
    services.AddScoped<IMongoRepository, MongoRepository>();

    services.AddScoped<IInteractorUseCase<AccountModel.AccessAccount, bool>, AccessAccountUseCase>();
    services.AddScoped<IInteractorUseCase<AccountModel.RegisterAccount, Guid>, RegisterAccountUseCase>();
    services.AddScoped<IInteractorUseCase<ValueTask, IEnumerable<ProductModel.RecoverProduct>>, RecoverProductsUseCase>();
    services.AddScoped<IInteractorUseCase<ProductModel.AcquireProduct, Guid>, RegisterProductUseCase>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMultitenancy<AppTenant>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
