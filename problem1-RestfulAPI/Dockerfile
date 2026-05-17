FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["problem1-RestfulAPI.csproj", "."]
RUN dotnet restore "problem1-RestfulAPI.csproj"

COPY . .
RUN dotnet build "problem1-RestfulAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "problem1-RestfulAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER $APP_UID

ENTRYPOINT ["dotnet", "problem1-RestfulAPI.dll"]