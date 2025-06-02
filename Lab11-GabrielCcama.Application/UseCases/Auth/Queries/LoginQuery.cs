using Lab11_GabrielCcama.Application.Interfaces;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Auth.Queries;

public class LoginQuery : IRequest<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

internal sealed class LoginQueryHandler(IJwtService jwtService, IUnitOfWork unitOfWork) 
    : IRequestHandler<LoginQuery, string>
{
    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByUsernameAsync(request.Username);
        
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Credenciales inválidas.");

        return jwtService.GenerateToken(user);
    }
}