using System.Reflection;
using Lab11_GabrielCcama.Application.Interfaces;
using Lab11_GabrielCcama.Domain.Interfaces;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Context;
using Lab11_GabrielCcama.Infrastructure.Repositories;
using Lab11_GabrielCcama.Infrastructure.Repositories.Base;
using Lab11_GabrielCcama.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab11_GabrielCcama.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
   public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
      IConfiguration configuration)
   {
      // Connexión a la base de datos
      services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
      {
         var connectionString = configuration.GetConnectionString("DefaultConnection");
         options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
      });
      
      // UnitOfWork
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      
      // Registro de repositorios
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IRoleRepository, RoleRepository>();
      services.AddScoped<ITicketRepository, TicketRepository>();
      services.AddScoped<IResponseRepository, ResponseRepository>();

      // Registro de servicios
      services.AddScoped<IJwtService, JwtService>();
      
      return services;
   } 
}