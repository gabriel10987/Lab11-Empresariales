using Lab11_GabrielCcama.Application.UseCases.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_GabrielCcama.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController(IMediator mediator) : ControllerBase
{
    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesByNames()
    {
        var roles = await mediator.Send(new GetRolesQuery());
        return Ok(roles);
    }
}