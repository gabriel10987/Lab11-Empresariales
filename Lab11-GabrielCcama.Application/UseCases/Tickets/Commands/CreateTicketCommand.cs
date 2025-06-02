using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Tickets.Commands;

public class CreateTicketCommand : IRequest<int>
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

internal sealed class CreateTicketCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateTicketCommand, int>
{
    public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Status = "abierto",
            CreatedAt = DateTime.UtcNow
        };

        await unitOfWork.TicketRepository.AddAsync(ticket);
        await unitOfWork.Complete();

        return ticket.TicketId;
    }

}