FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 8080
EXPOSE 443

COPY Backend.sln ./
COPY src ./src

WORKDIR /app/src/hosts/WebApi

RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:7.0

RUN apt-get update
RUN apt-get install tzdata -y
RUN ln -fs /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata

RUN groupadd -r app && useradd -r -g app app
WORKDIR /app
COPY --from=build-env /app/src/hosts/WebApi/out .
RUN chown -R app:app /app

USER app

ENTRYPOINT ["dotnet", "WebApi.dll"]   