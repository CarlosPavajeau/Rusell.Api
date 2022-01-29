FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/Parcels/Parcels.csproj" "src/Parcels/Parcels.csproj"
COPY "apps/Parcels.Api/Parcels.Api.csproj" "apps/Parcels.Api/Parcels.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/Parcels.Api/Parcels.Api.csproj"

COPY . .
WORKDIR "/src/apps/Parcels.Api"
RUN dotnet build "Parcels.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Parcels.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.Parcels.Api.dll"]
