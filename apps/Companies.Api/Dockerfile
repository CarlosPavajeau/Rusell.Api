FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY Rusell.sln Rusell.sln

COPY "src/Addresses/Addresses.csproj" "src/Addresses/Addresses.csproj"
COPY "apps/Addresses.Api/Addresses.Api.csproj" "apps/Addresses.Api/Addresses.Api.csproj"
COPY "src/Companies/Companies.csproj" "src/Companies/Companies.csproj"
COPY "apps/Companies.Api/Companies.Api.csproj" "apps/Companies.Api/Companies.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"
COPY "test/src/Test.Shared/Test.Shared.csproj" "test/src/Test.Shared/Test.Shared.csproj"
COPY "test/src/Test.Addresses/Test.Addresses.csproj" "test/src/Test.Addresses/Test.Addresses.csproj"
COPY "test/src/Test.Companies/Test.Companies.csproj" "test/src/Test.Companies/Test.Companies.csproj"

RUN dotnet restore "Rusell.sln"

COPY . .
WORKDIR "/src/apps/Companies.Api"
RUN dotnet build -c Release

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Companies.Api.dll"]
