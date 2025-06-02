using System.Text;
using Lab11_GabrielCcama.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Lab11_GabrielCcama.Api.Configuration;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        
        // Registro del archivo de configuración de Infrastructure
        services.AddInfrastructureServices(configuration);
        
        // Configuración de Jwt
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = "TuIssuer",
                ValidAudience = "TuAudience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
            };
        });
        
        // Habilitar controladores
        services.AddControllers();
        
        // Habilitar Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Lab6-GabrielCcama", Version = "v1" });
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Introduce el token JWT con el prefijo 'Bearer '",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
    
            c.AddSecurityDefinition("Bearer", securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    securityScheme,
                    new string[] { }
                }
            };
    
            c.AddSecurityRequirement(securityRequirement);
        });
        
        return services;
    }
}