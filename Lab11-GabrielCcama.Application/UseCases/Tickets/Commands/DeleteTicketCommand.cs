using Lab11_GabrielCcama.Domain.Interfaces.Base;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Tickets.Commands;

public class DeleteTicketCommand : IRequest<bool>
{
    public int TicketId { get; set; }
}

internal sealed class DeleteTicketCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteTicketCommand, bool>
{
    public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.TicketRepository.DeleteTicketAsync(request.TicketId);
        await unitOfWork.Complete();
        return true;
    }
}
