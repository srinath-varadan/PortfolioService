# Dockerfile (for .NET 9)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Adjust COPY if your csproj is at root or inside folder
COPY ["PortfolioService.csproj", "./"]
RUN dotnet restore "PortfolioService.csproj"

COPY . .
RUN dotnet publish "PortfolioService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PortfolioService.dll"]