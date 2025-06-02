using Lab11_GabrielCcama.Application.DTOs;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Tickets.Queries;

public class GetOpenTicketsQuery :  IRequest<IEnumerable<OpenTicketDto>> { }

internal sealed class GetOpenTicketsQueryHandler(IUnitOfWork unitOfWork) : 
    IRequestHandler<GetOpenTicketsQuery, IEnumerable<OpenTicketDto>>
{
    public async Task<IEnumerable<OpenTicketDto>> Handle(GetOpenTicketsQuery request, 
        CancellationToken cancellationToken)
    {
        var tickets = await unitOfWork.TicketRepository.GetOpenTicketsAsync();

        var result = tickets.Select(t => new OpenTicketDto
        {
            TicketId = t.TicketId,
            Title = t.Title,
            Status = t.Status,
            CreatedAt = t.CreatedAt,
        });
        
        return result;
    }
}