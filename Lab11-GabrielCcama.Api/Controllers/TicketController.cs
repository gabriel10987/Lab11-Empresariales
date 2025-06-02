using Lab11_GabrielCcama.Application.UseCases.Tickets.Commands;
using Lab11_GabrielCcama.Application.UseCases.Tickets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_GabrielCcama.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetTicketByUserId([FromRoute] int userId)
    {
        var tickets = await mediator.Send(new GetTicketsByUserIdQuery{UserId = userId});
        return Ok(tickets);
    }
    
    [HttpPost("createTicket")]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
    {
        var ticketId = await mediator.Send(command);
        return Ok(new { TicketId = ticketId });
    }

    [HttpDelete("deleteTicket/{ticketId}")]
    public async Task<IActionResult> DeleteTicket(int ticketId)
    {
        var success = await mediator.Send(new DeleteTicketCommand { TicketId = ticketId });
        return success ? Ok("Ticket eliminado") : NotFound("Ticket no encontrado");
    }

    [HttpGet("open")]
    public async Task<IActionResult> GetOpenTickets()
    {
        var tickets = await mediator.Send(new GetOpenTicketsQuery());
        return Ok(tickets);
    }

}