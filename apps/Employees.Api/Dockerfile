FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/Employees/Employees.csproj" "src/Employees/Employees.csproj"
COPY "apps/Employees.Api/Employees.Api.csproj" "apps/Employees.Api/Employees.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/Employees.Api/Employees.Api.csproj"

COPY . .
WORKDIR "/src/apps/Employees.Api"
RUN dotnet build "Employees.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Employees.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.Employees.Api.dll"]
