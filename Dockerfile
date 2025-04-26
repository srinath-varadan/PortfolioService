# Use official .NET 8 runtime for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Build stage with SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only csproj and restore early (better caching)
COPY ["PortfolioService.csproj", "./"]
RUN dotnet restore "PortfolioService.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "PortfolioService.csproj" -c Release -o /app/publish

# Final runtime stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PortfolioService.dll"]