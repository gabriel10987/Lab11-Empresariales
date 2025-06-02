using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using MediatR;

namespace Lab11_GabrielCcama.Application.UseCases.Auth.Command;

public class RegisterUserCommand : IRequest<int>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}

internal sealed class RegisterUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, int>
{

    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await unitOfWork.UserRepository.GetByUsernameAsync(request.Username);
        if (existingUser != null) throw new Exception("Usuario ya existe");
        
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Username = request.Username,
            PasswordHash = hashedPassword,
            Email = request.Email
        };
        
        // Obtener roles desde la base de datos
        var roles = await unitOfWork.RoleRepository.GetByNamesAsync(request.Roles);

        // Asignar roles al usuario
        foreach (var role in roles)
        {
            user.UserRoles.Add(new UserRole
            {
                User = user,
                Role = role
            });
        }

        await unitOfWork.UserRepository.AddAsync(user);
        await unitOfWork.Complete();
        
        return user.UserId;
    }
}