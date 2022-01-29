FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/Tickets/Tickets.csproj" "src/Tickets/Tickets.csproj"
COPY "apps/Tickets.Api/Tickets.Api.csproj" "apps/Tickets.Api/Tickets.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/Tickets.Api/Tickets.Api.csproj"

COPY . .
WORKDIR "/src/apps/Tickets.Api"
RUN dotnet build "Tickets.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tickets.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.Tickets.Api.dll"]
