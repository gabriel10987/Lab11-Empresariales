using Microsoft.AspNetCore.Mvc;

namespace Lab11_GabrielCcama.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Versión 1.0 - Despliegue exitoso");
    }
}