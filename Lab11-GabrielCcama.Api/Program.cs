using Lab11_GabrielCcama.Api.Configuration;
using Lab11_GabrielCcama.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registrar configuración centralizada
builder.Services.AddApplicationServices(builder.Configuration);

// Registrar MediatR con clase marcador
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(ApplicationAssemblyMarker).Assembly
));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

// JWT BEARER TOKEN
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
