using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Responses.Commands;

public class CreateResponseCommand : IRequest<int>
{
    public int TickedId { get; set; }
    public int ResponderId { get; set; }
    public string Message { get; set; }
}

internal sealed class CreateResponseCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateResponseCommand, int>
{
    public async Task<int> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        var response = new Response
        {
            TicketId = request.TickedId,
            ResponderId = request.ResponderId,
            Message = request.Message,
            CreatedAt = DateTime.UtcNow
        };

        await unitOfWork.ResponseRepository.AddResponseAsync(response);
        await unitOfWork.Complete();

        return response.ResponseId;
    }
}