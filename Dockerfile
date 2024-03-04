FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY Backend.sln ./
COPY src ./src
WORKDIR /app/src/hosts/WebApi

RUN dotnet restore
FROM build AS publish
RUN dotnet publish -c Release -o /app/out /p:UseAppHost=false

RUN apt-get update
RUN apt-get install tzdata -y
RUN ln -fs /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata

FROM base AS final
WORKDIR /app
COPY --from=publish /app/out .
# COPY ./certificate.pfx /app
RUN groupadd -r app && useradd -r -g app app
RUN chown -R app:app /app

ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development
USER app

ENTRYPOINT ["dotnet", "WebApi.dll"]