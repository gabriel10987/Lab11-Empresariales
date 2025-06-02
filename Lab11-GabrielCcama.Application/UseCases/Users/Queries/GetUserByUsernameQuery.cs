using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Users.Queries;

public class GetUserByUsernameQuery :  IRequest<User?>
{
    public string Username { get; set; }
}

internal sealed class GetUserByUsernameQueryHandler(IUnitOfWork unitOfWork) : 
    IRequestHandler<GetUserByUsernameQuery, User?>
{
    public async Task<User?> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.UserRepository.GetByUsernameAsync(request.Username);
    }
}
