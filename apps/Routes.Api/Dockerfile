FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/Routes/Routes.csproj" "src/Routes/Routes.csproj"
COPY "apps/Routes.Api/Routes.Api.csproj" "apps/Routes.Api/Routes.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/Routes.Api/Routes.Api.csproj"

COPY . .
WORKDIR "/src/apps/Routes.Api"
RUN dotnet build "Routes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Routes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.Routes.Api.dll"]
