using Lab11_GabrielCcama.Application.UseCases.Responses.Commands;
using Lab11_GabrielCcama.Application.UseCases.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_GabrielCcama.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponseController(IMediator mediator) : ControllerBase
{
    [HttpGet("ticket/{ticketId}")]
    public async Task<IActionResult> GetResponsesByTicketId(int ticketId)
    {
        var responses = await mediator.Send(new GetResponsesByTicketIdQuery{TicketId = ticketId});
    return Ok(responses);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateResponse([FromBody] CreateResponseCommand command)
    {
        var responseId = await mediator.Send(command);
        return Ok(new { ResponseId = responseId });
    }

}