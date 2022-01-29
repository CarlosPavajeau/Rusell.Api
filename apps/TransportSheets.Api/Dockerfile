FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/TransportSheets/TransportSheets.csproj" "src/TransportSheets/TransportSheets.csproj"
COPY "apps/TransportSheets.Api/TransportSheets.Api.csproj" "apps/TransportSheets.Api/TransportSheets.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/TransportSheets.Api/TransportSheets.Api.csproj"

COPY . .
WORKDIR "/src/apps/TransportSheets.Api"
RUN dotnet build "TransportSheets.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransportSheets.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.TransportSheets.Api.dll"]
