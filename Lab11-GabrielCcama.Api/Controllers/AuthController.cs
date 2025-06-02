using Lab11_GabrielCcama.Application.UseCases.Auth.Command;
using Lab11_GabrielCcama.Application.UseCases.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_GabrielCcama.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<string> Login([FromBody] LoginQuery request)
    {
        return await mediator.Send(request);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
    {
        await mediator.Send(request);
        return Ok(new { Message = "El usuario se registró correctamente" });
    }
}