using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Infrastructure.Scaffold;

namespace Lab11_GabrielCcama.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}