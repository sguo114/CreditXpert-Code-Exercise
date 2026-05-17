FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["CountriesApi.csproj", "."]
RUN dotnet restore "CountriesApi.csproj"

COPY . .
RUN dotnet build "CountriesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CountriesApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run as a non-root user for production safety
USER $APP_UID

ENTRYPOINT ["dotnet", "CountriesApi.dll"]