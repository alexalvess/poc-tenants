using Hybrid.Tenant.Sample.Models;
using Hybrid.Tenant.Sample.UseCases.Abstractions.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hybrid.Tenant.Sample.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : Controller
{
    private readonly IInteractorUseCase<AccountModel.RegisterAccount, Guid> _register;
    private readonly IInteractorUseCase<AccountModel.AccessAccount, bool> _access;

    public AccountController(
        IInteractorUseCase<AccountModel.RegisterAccount, Guid> register, 
        IInteractorUseCase<AccountModel.AccessAccount, bool> access)
    {
        _register = register;
        _access = access;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(
        [FromHeader(Name = "x-user")] string user,
        [FromBody] AccountModel.RegisterAccount model, 
        CancellationToken cancellationToken)
    {
        var accountId = await _register.InteractAsync(user, model, cancellationToken);
        return Created("/access", accountId);
    }

    [HttpGet("access")]
    public async Task<IActionResult> AccessAsync(
        [FromHeader(Name = "x-user")] string user,
        [FromQuery] AccountModel.AccessAccount model, 
        CancellationToken cancellationToken)
    {
        var access = await _access.InteractAsync(user, model, cancellationToken);
        return access ? Ok() : BadRequest();
    }
}
