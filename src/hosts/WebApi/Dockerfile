FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/hosts/WebApi/WebApi.csproj", "src/hosts/WebApi/"]
COPY ["src/lib/Infrastructure/Infrastructure.csproj", "src/lib/Infrastructure/"]
COPY ["src/lib/Domain/Domain.csproj", "src/lib/Domain/"]
RUN dotnet restore "src/hosts/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/src/hosts/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]