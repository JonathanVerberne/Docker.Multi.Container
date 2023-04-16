# https://github.com/docker/awesome-compose/blob/master/aspnet-mssql/app/aspnetapp/Dockerfile
# https://www.jetbrains.com/dotnet/guide/tutorials/docker-dotnet/aspnet-development-docker/

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web.Application.csproj", "./"]
RUN dotnet restore "Web.Application.csproj"
COPY . ./

RUN dotnet build "Web.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Application.dll"]

