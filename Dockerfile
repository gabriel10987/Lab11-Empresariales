# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos todo
COPY . ./

# Restauramos dependencias de la solución
RUN dotnet restore Lab11-GabrielCcama.sln

# Publicamos el proyecto de entrada (Lab11)
RUN dotnet publish Lab11-GabrielCcama.Api/Lab11-GabrielCcama.Api.csproj -c Release -o /out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiamos desde la etapa de build
COPY --from=build /out .

# Puerto dinámico para Render
ENV ASPNETCORE_URLS=http://+:$PORT

# Comando de inicio
ENTRYPOINT ["dotnet", "Lab11-GabrielCcama.Api.dll"]