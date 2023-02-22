using Hybrid.Tenant.Sample.Models;
using Hybrid.Tenant.Sample.UseCases.Abstractions.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hybrid.Tenant.Sample.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : Controller
{
    private readonly IInteractorUseCase<ProductModel.AcquireProduct, Guid> _acquire;
    private readonly IInteractorUseCase<ValueTask, IEnumerable<ProductModel.RecoverProduct>> _recover;

    public ProductController(
        IInteractorUseCase<ProductModel.AcquireProduct, Guid> acquire, 
        IInteractorUseCase<ValueTask, IEnumerable<ProductModel.RecoverProduct>> recover)
    {
        _acquire = acquire;
        _recover = recover;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(
        [FromHeader(Name = "x-user")] string user,
        [FromBody] ProductModel.AcquireProduct product, 
        CancellationToken cancellationToken)
    {
        var productId = await _acquire.InteractAsync(user, product, cancellationToken);
        return Created("detail", productId);
    }

    [HttpGet]
    public async Task<IActionResult> RecoverAsync(
        [FromHeader(Name = "x-user")] string user,
        CancellationToken cancellationToken)
    {
        var products = await _recover.InteractAsync(user, default, cancellationToken);
        return Ok(products);
    }
}
