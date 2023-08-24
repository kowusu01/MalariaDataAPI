#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-stage
WORKDIR src
copy . .
RUN ls .
RUN  dotnet build /src/Malaria.API/MalariaDataApi.csproj -t:Rebuild -p:Configuration=Debug -o build

from build-stage AS final
WORKDIR /app
COPY --from=build-stage build .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "MalariaDataAPI.dll"]