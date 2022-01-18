FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/Clients/Clients.csproj" "src/Clients/Clients.csproj"
COPY "apps/Clients.Api/Clients.Api.csproj" "apps/Clients.Api/Clients.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/Clients.Api/Clients.Api.csproj"

COPY . .
WORKDIR "/src/apps/Clients.Api"
RUN dotnet build "Clients.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clients.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.Clients.Api.dll"]
