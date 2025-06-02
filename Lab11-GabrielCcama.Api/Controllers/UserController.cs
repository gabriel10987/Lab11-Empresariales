using Lab11_GabrielCcama.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_GabrielCcama.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await mediator.Send(new GetUserByUsernameQuery { Username = username });
        return user != null ? Ok(user) : NotFound("Usuario no encontrado");
    }

}