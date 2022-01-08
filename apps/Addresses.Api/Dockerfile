FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Rusell.sln Rusell.sln

COPY "src/Addresses/Addresses.csproj" "src/Addresses/Addresses.csproj"
COPY "apps/Addresses.Api/Addresses.Api.csproj" "apps/Addresses.Api/Addresses.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/Addresses.Api/Addresses.Api.csproj"

COPY . .
WORKDIR "/src/apps/Addresses.Api"
RUN dotnet build "Addresses.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Addresses.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.Addresses.Api.dll"]
