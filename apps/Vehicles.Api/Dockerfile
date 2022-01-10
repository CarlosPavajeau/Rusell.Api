FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/Vehicles/Vehicles.csproj" "src/Vehicles/Vehicles.csproj"
COPY "src/Vehicles.Api/Vehicles.Api.csproj" "src/Vehicles.Api/Vehicles.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/Vehicles.Api/Vehicles.Api.csproj"

COPY . .
WORKDIR "/src/apps/Vehicles.Api"
RUN dotnet build "Vehicles.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vehicles.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.Vehicles.Api.dll"]
