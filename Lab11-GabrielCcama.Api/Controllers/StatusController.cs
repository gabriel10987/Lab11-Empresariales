using Microsoft.AspNetCore.Mvc;

namespace Lab11_GabrielCcama.Api.Controllers;

[ApiController]
[Route("/")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStatus() => Ok(new { message = "Despliegue exitoso. API Lab11 corriendo correctamente"});
}