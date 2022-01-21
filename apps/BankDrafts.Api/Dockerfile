FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "src/BankDrafts/BankDrafts.csproj" "src/BankDrafts/BankDrafts.csproj"
COPY "apps/BankDrafts.Api/BankDrafts.Api.csproj" "apps/BankDrafts.Api/BankDrafts.Api.csproj"
COPY "src/Shared/Shared.csproj" "src/Shared/Shared.csproj"

RUN dotnet restore "apps/BankDrafts.Api/BankDrafts.Api.csproj"

COPY . .
WORKDIR "/src/apps/BankDrafts.Api"
RUN dotnet build "BankDrafts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankDrafts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rusell.BankDrafts.Api.dll"]
