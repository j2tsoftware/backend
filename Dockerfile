FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy everything else and build
COPY Backend.sln ./
COPY src ./src

WORKDIR /app/src/hosts/WebApi

# Copy csproj and restore as distinct layers
RUN dotnet restore
RUN dotnet publish -c Release -o out

#Runtime
FROM mcr.microsoft.com/dotnet/sdk:7.0

RUN apt-get update
RUN apt-get install tzdata -y
RUN ln -fs /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata

RUN groupadd -r app && useradd -r -g app app
WORKDIR /app
COPY --from=build-env /app/src/hosts/WebApi/out .
RUN chown -R app:app /app

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080
EXPOSE 443
USER app

ENTRYPOINT ["dotnet", "WebApi.dll"]   