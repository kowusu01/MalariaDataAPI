#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app
COPY . /app


# container port 80
# in the docker-compose, this will be mapped to port 8081 on the host
EXPOSE 80

# currently not mapped in the docker compose
EXPOSE 443


# healthcheck 
HEALTHCHECK CMD	curl --fail http://localhost:8081/api/health-check/db

# entrypoiunt
ENTRYPOINT ["dotnet", "MalariaDataAPI.dll"]