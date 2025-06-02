using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Responses.Queries;

public class GetResponsesByTicketIdQuery : IRequest<IEnumerable<Response>>, IRequest<IEnumerable<int>>
{
    public int TicketId { get; set; }
}

internal sealed class GetResponsesByTicketIdQueryHandler(IUnitOfWork unitOfWork) : 
    IRequestHandler<GetResponsesByTicketIdQuery, IEnumerable<Response>>
{
    public async Task<IEnumerable<Response>> Handle(GetResponsesByTicketIdQuery request, 
        CancellationToken cancellationToken)
    {
        return await unitOfWork.ResponseRepository.GetResponsesByTicketIdAsync(request.TicketId);
    }

}