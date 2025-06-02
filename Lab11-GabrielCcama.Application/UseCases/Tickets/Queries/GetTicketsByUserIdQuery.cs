using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Tickets.Queries;

public class GetTicketsByUserIdQuery : IRequest<IEnumerable<Ticket>>
{
    public int UserId { get; set; }
}

internal sealed class GetTicketsByUserIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTicketsByUserIdQuery, 
    IEnumerable<Ticket>>
{
    public async Task<IEnumerable<Ticket>> Handle(GetTicketsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.TicketRepository.GetTicketsByUserIdAsync(request.UserId);
    }
}