# Use official .NET 8 SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PortfolioService/PortfolioService.csproj", "PortfolioService/"]
RUN dotnet restore "PortfolioService/PortfolioService.csproj"
COPY . .
WORKDIR "/src/PortfolioService"
RUN dotnet publish "PortfolioService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PortfolioService.dll"]