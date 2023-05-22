
# 
#dotnet user-secrets init
#dotnet user-secrets set  "DataSourceType" "InMemory"
#dotnet user-secrets set  "DBInstance" "studentsdb"
dotnet run --launch-profile InMemoryDb StudentPrototype.API.csproj

# docker execute  - InMemory DB
#  docker run -ti -p 8081:80 -e DataSourceType="InMemory" -e DBInstance="malariadb_dev" -e ASPNETCORE_ENVIRONMENT="Development" --name=api.malaria.dev  malaria-api

# docker execute app with postgres DB
# - start postgres docker
# - start the api docker linking to the postgres docker for sb access
docker run -ti -p 8081:80 -e DBInstance="malariadb_dev" -e DataSourceType="Server" -e DBServer="server:port" -e DBInstance="malariadb_dev" -e  DBUsername="youruser" -e DBPassword="yourpass" -e ASPNETCORE_ENVIRONMENT="Development" --name=api.malaria.dev  --link dev.postgres.db  malaria-api

# https://localhost:7096/swagger/index.html
# http://localhost:7096/swagger/index.html
https://localhost:8081/swagger/index.html
